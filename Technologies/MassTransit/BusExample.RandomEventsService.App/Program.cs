using BusExample.RandomEventsService.App;
using SeedWork.Infrastructure.MassTransit.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => 
    {
        services.AddHostedService<Worker>();
        services.AddMessaging(context.Configuration);
    })
    .Build();

await host.RunAsync();