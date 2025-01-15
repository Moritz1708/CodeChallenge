using Application.Models.Dtos;
using AutoMapper;
using Domain.CQRS;
using Infrastructure.Services.Events;
using Infrastructure.Services.Statistic;

namespace Application.Feature.Statistic.Queries.GetStatisticByEvent;

public class GetStatisticByEventQueryHandler(IStatisticService statisticService, IMapper mapper)
    : IQueryHandler<GetStatisticByEventQuery, GetStatisticByEventResult>
{
    public async Task<GetStatisticByEventResult> Handle(GetStatisticByEventQuery request, CancellationToken cancellationToken)
    {
        var statistic = await statisticService.GetStatisticFromEvent(request.EventId, request.EventType);
        
        var statisticDto = mapper.Map<StatisticDto>(statistic);
        
        return new GetStatisticByEventResult(statisticDto);
    }
}