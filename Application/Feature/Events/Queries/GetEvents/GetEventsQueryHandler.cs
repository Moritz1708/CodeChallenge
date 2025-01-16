namespace Application.Feature.Events.Queries.GetEvents;

public class GetEventsQueryHandler(IEventService eventService, IMapper mapper) 
    : IQueryHandler<GetEventsQuery, GetEventsQueryResult>
{
    public async Task<GetEventsQueryResult> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await eventService.GetEvents();
        
        var eventDtos = events.Select(mapper.Map<EventDto>).ToList();
        
        return new GetEventsQueryResult(eventDtos);
    }
}