namespace BusExample.RandomEvents.Contracts;

public class RandomEvent
{
    public Guid Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public int Value { get; set; }
}