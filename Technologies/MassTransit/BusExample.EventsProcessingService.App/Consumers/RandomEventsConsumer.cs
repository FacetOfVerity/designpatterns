using BusExample.EventsProcessingService.Contracts;
using BusExample.RandomEvents.Contracts;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using SeedWork.Infrastructure.Abstractions;

namespace BusExample.EventsProcessingService.App.Consumers;

public class RandomEventsConsumer : IConsumer<RandomEvent>
{
    private readonly ILogger<RandomEventsConsumer> _logger;
    private readonly IServiceBus _bus;
    private readonly IDistributedCache _cache;

    public RandomEventsConsumer(ILogger<RandomEventsConsumer> logger, IServiceBus bus, IDistributedCache cache)
    {
        _logger = logger;
        _bus = bus;
        _cache = cache;
    }

    public async Task Consume(ConsumeContext<RandomEvent> context)
    {
        var data = context.Message;
        _logger.LogInformation($"Random event {data.Id} received");

        var cache = await _cache.GetStringAsync(data.Value.ToString());
        int count = cache is null ? 0 : int.Parse(cache);
        count++;
        
        await _cache.SetStringAsync(data.Value.ToString(), count.ToString());

        var newEvent = new ProcessedEvent
        {
            Id = data.Id,
            CreatedAt = DateTimeOffset.UtcNow,
            Value = data.Value,
            Repeated = count
        };

        await _bus.PublishEvent(newEvent);
    }
}