

using Domain.Entities;

namespace Application.Models.Dtos;

public record HardwareReservationDto
{
    public Guid EventId { get; set; }
    public int Menge { get; init; } = 0;
    public Hardware Hardware { get; init; }
}