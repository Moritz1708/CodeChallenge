namespace Domain.Entities;

public record Statistic
{
    public int? Attendees { get; init; }
    public int? Invites { get; init; }
    public int? Visits { get; init; }
    public int? VirtualRooms { get; init; }
    public int? VisitorsCount { get; init; }
    public int? ExhibitorsCount { get; init; }
    public int? BoothsCount { get; init; }
}