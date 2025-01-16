namespace Application.Models.Dtos;

public record EventDto(
    Guid Id,
    int Year,
    string Name,
    EventType Type,
    DateTime? StartDate,
    DateTime? EndDate,
    [property: System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    List<StatisticDto?> Statistic
)
{
    public EventDto() : this(Guid.Empty, 0, string.Empty, default, null, null, null) { }
}