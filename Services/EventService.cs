using Microsoft.EntityFrameworkCore;
using SmartEvent.API.Data;
using SmartEvent.API.Models;

namespace SmartEvent.API.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events.Include(e => e.Registrations).ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Registrations)
                                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> CreateEventAsync(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<bool> UpdateEventAsync(Event ev)
        {
            _context.Entry(ev).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return false;

            _context.Events.Remove(ev);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
