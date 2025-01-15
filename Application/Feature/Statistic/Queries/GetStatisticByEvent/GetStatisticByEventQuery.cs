using Application.Models.Dtos;
using Domain.CQRS;
using Domain.Entities;

namespace Application.Feature.Statistic.Queries.GetStatisticByEvent;

public record GetStatisticByEventQuery(Guid EventId, EventType EventType) 
    : IQuery<GetStatisticByEventResult>;

public record GetStatisticByEventResult(StatisticDto StatisticDto);