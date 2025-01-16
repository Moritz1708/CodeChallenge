namespace Application.Feature.Events.Queries.GetEventsById;

public record GetEventByIdQuery(Guid Id) : IQuery<GetEventByIdQueryResult>;

public class GetEventByIdQueryResult(EventDto @event)
{
    public EventDto Event { get; set; } = @event;
};