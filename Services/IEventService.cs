using SmartEvent.API.Models;

namespace SmartEvent.API.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task<Event> CreateEventAsync(Event ev);
        Task<bool> UpdateEventAsync(Event ev);
        Task<bool> DeleteEventAsync(int id);
    }
}
