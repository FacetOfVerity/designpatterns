using BusExample.RandomEvents.Contracts;
using SeedWork.Infrastructure.Abstractions;

namespace BusExample.RandomEventsService.App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var random = new Random(DateTimeOffset.UtcNow.Millisecond);
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var bus = scope.ServiceProvider.GetRequiredService<IServiceBus>();
                var value = random.Next(0, 10);

                var randomEvent = new RandomEvent
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTimeOffset.UtcNow,
                    Value = value
                };

                await bus.PublishEvent(randomEvent);

                _logger.LogInformation($"New RandomEvent {randomEvent.Id} published.");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}