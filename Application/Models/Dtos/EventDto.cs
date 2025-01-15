using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Models.Dtos;

public record EventDto(
    Guid Id,
    int Year,
    string Name,
    EventType Type,
    DateTime? StartDate,
    DateTime? EndDate,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    StatisticDto? Statistic
)
{
    public EventDto() : this(Guid.Empty, 0, string.Empty, default, null, null, null) { }
}