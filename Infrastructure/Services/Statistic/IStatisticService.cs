using Domain.Entities;

namespace Infrastructure.Services.Statistic;

public interface IStatisticService
{
    Task<Domain.Entities.Statistic> GetStatisticFromEvent(Guid eventId, EventType eventType);
}

