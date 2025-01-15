using Domain.Entities;

namespace Infrastructure.Services.Events;

public interface IEventService
{
  Task<Event> GetEvent(Guid id);
  Task<IList<Event>> GetEvents();
}
