using BusExample.EventsProcessingService.Contracts;
using MassTransit;

namespace BusExample.EventsLoggingService.App.Consumers;

public class ProcessedEventsConsumer : IConsumer<ProcessedEvent>
{
    private readonly ILogger<ProcessedEventsConsumer> _logger;

    public ProcessedEventsConsumer(ILogger<ProcessedEventsConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<ProcessedEvent> context)
    {
        var data = context.Message;
        _logger.LogInformation(
            $"Processed event {data.Id} received: CreatedAt {data.CreatedAt.ToString("HH:m:s tt zzz")}; Value {data.Value}; Repeted: {data.Repeated}");
        
        return Task.CompletedTask;
    }
}