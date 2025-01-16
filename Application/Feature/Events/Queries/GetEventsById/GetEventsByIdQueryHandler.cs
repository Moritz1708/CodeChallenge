namespace Application.Feature.Events.Queries.GetEventsById;

public class GetEventsByIdQueryHandler(IEventService eventService, IMapper mapper) 
    : IQueryHandler<GetEventByIdQuery, GetEventByIdQueryResult>
{
    public async Task<GetEventByIdQueryResult> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await eventService.GetEvent(request.Id);
        
        var eventDto = mapper.Map<EventDto>(@event);
        
        return new GetEventByIdQueryResult(eventDto);
    }
}