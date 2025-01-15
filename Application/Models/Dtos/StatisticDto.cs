using System.Text.Json.Serialization;

namespace Application.Models.Dtos;


public record StatisticDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Attendees { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Invites { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Visits { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? VirtualRooms { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? VisitorsCount { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ExhibitorsCount { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BoothsCount { get; init; }
    
    public StatisticDto(
        int? visitorsCount,
        int? exhibitorsCount,
        int? boothsCount)
    {
        VisitorsCount = visitorsCount;
        ExhibitorsCount = exhibitorsCount;
        BoothsCount = boothsCount;
    }
    
    public StatisticDto(
        int? attendees,
        int? invites,
        int? visits,
        int? virtualRooms)
    {
        Attendees = attendees;
        Invites = invites;
        Visits = visits;
        VirtualRooms = virtualRooms;
    }
}