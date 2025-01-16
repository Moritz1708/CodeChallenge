namespace Infrastructure.Services.Statistic;

public interface IStatisticService
{
    Task<List<Domain.Entities.Statistic>> GetStatisticFromEvent(Guid eventId, EventType eventType);
}

