using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedWork.Infrastructure.Abstractions;

namespace SeedWork.Infrastructure.MassTransit.Extensions
{
    /// <summary/>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var endpointOptions = new RabbitMqEndpointOptions();
            configuration.GetSection("Messaging").Bind(endpointOptions);
            if (endpointOptions == null)
            {
                throw new ArgumentNullException(nameof(endpointOptions));
            }

            endpointOptions.Validate();

            services.AddScoped<IServiceBus, ServiceBus>();
            services.AddMassTransit(builder =>
            {
                builder.AddConsumers(
                    AutoRegistrationFilter,
                    Assembly.GetEntryAssembly()
                );

                builder.UsingRabbitMq(ConfigureBus);
            });
            
            services.AddMassTransitHostedService();

            return services;

            void ConfigureBus(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator cfg)
            {
                cfg.Host(endpointOptions.Host, endpointOptions.VirtualHost,
                    options =>
                    {
                        options.Username(endpointOptions.Username);
                        options.Password(endpointOptions.Password);
                    });

                cfg.ReceiveEndpoint(endpointOptions.ReceiveEndpoint, ep =>
                {
                    ep.PrefetchCount = 8;
                    ep.UseMessageRetry(r =>
                    {
                        SetInterval(r, endpointOptions.RetryCount, 100);
                    });

                    var unconfiguredConsumers = FindConsumerTypesWithoutExplicitDefinitions(Assembly.GetEntryAssembly());
                    foreach (var consumer in unconfiguredConsumers)
                    {
                        ep.ConfigureConsumer(context, consumer);
                    }
                });
                
                cfg.ConfigureEndpoints(context);
            }
            
            IRetryConfigurator SetInterval(IRetryConfigurator configurator, int retryCount, int interval)
            {
                if (retryCount <= 0)
                {
                    configurator.None();
                }
                else
                {
                    configurator.Interval(retryCount, interval);
                }
                return configurator;
            }

            Type[] FindConsumerTypesWithoutExplicitDefinitions(Assembly assembly)
            {
                var consumerDefinitions = assembly.GetTypes()
                    .SelectMany(a => a.GetInterfaces().Where(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumerDefinition<>)));

                var configuredConsumers = consumerDefinitions
                    .SelectMany(a => a.GenericTypeArguments)
                    .ToArray();

                var consumersWithoutConfiguration = assembly.GetTypes()
                    .Where(AutoRegistrationFilter)
                    .Where(a => a.GetInterfaces()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumer<>)))
                    .Except(configuredConsumers)
                    .ToArray();

                return consumersWithoutConfiguration;
            }

            bool AutoRegistrationFilter(Type type) => type.GetCustomAttribute<DisableConsumerAutoRegistrationAttribute>() == null;
        }
    }
}
