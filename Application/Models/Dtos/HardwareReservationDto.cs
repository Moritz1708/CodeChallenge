namespace Application.Models.Dtos;

public record HardwareReservationDto
{
    public int Menge { get; init; } = 0;
    public string Hardware { get; init; } = string.Empty;
    public required Event Event { get; set; }
}