namespace Application.Models.Dtos;

public record HardwareReservationDto
{
    public int Menge { get; init; } = 0;
    public Hardware Hardware { get; init; }
    public required Event Event { get; set; }
}