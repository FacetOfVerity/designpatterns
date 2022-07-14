using MassTransit;
using SeedWork.Infrastructure.Abstractions;

namespace SeedWork.Infrastructure.MassTransit
{
    public class ServiceBus: IServiceBus
    {
        private readonly IPublishEndpoint _endpoint;

        public ServiceBus(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task PublishEvent(object integrationEvent)
        {
            await _endpoint.Publish(integrationEvent);
        }
    }
}