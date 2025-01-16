namespace Application.Feature.Statistic.Queries.GetStatisticByEvent;

public record GetStatisticByEventQuery(Guid EventId, EventType EventType) 
    : IQuery<GetStatisticByEventResult>;

public record GetStatisticByEventResult(List<StatisticDto> StatisticDto);