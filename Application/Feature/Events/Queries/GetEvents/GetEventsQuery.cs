

namespace Application.Feature.Events.Queries.GetEvents;

public record GetEventsQuery : IQuery<GetEventsQueryResult>;

public record GetEventsQueryResult(List<EventDto> Events);