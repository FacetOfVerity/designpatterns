namespace SeedWork.Infrastructure.Abstractions
{
    public interface IServiceBus
    {
        Task PublishEvent(object integrationEvent);
    }
}