using BusExample.RandomEvents.Contracts;
using MassTransit;

namespace BusExample.EventsLoggingService.App.Consumers;

public class RandomEventsConsumer : IConsumer<RandomEvent>
{
    private readonly ILogger<RandomEventsConsumer> _logger;

    public RandomEventsConsumer(ILogger<RandomEventsConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RandomEvent> context)
    {
        var data = context.Message;
        _logger.LogInformation(
            $"Random event {data.Id} received: CreatedAt {data.CreatedAt.ToString("HH:m:s tt zzz")}; Value {data.Value}");
        
        return Task.CompletedTask;
    }
}