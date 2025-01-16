namespace Domain.Entities;

public class HardwareReservation
{
    public Guid EventId { get; set; }
    public int Menge { get; init; } = 0;
    public Hardware Hardware { get; init; }
    public required Event Event { get; set; }
}