namespace BusExample.EventsProcessingService.Contracts;

public class ProcessedEvent
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public int Value { get; set; }
    
    public int Repeated { get; set; }
}