namespace Application.Feature.Statistic.Queries.GetStatisticByEvent;

public class GetStatisticByEventQueryHandler(IStatisticService statisticService, IMapper mapper)
    : IQueryHandler<GetStatisticByEventQuery, GetStatisticByEventResult>
{
    public async Task<GetStatisticByEventResult> Handle(GetStatisticByEventQuery request, CancellationToken cancellationToken)
    {
        var statistic = await statisticService.GetStatisticFromEvent(request.EventId, request.EventType);
        
        var statisticDto = statistic.Select(mapper.Map<StatisticDto>).ToList(); ;
        
        return new GetStatisticByEventResult(statisticDto);
    }
}