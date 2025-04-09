using Microsoft.AspNetCore.Mvc;
using SmartEvent.API.Data;
using SmartEvent.API.Models;

[Route("api/events")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetEvents()
    {
        try
        {
            return Ok(_context.Events.ToList());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Event> GetEventById(int id)
    {
        try
        {
            var eventItem = _context.Events.Find(id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            return Ok(eventItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Event> CreateEvent(Event newEvent)
    {
        try
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEvent(int id, Event updatedEvent)
    {
         try
        {
            var existingEvent = _context.Events.Find(id);
            if (existingEvent == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            existingEvent.Name = updatedEvent.Name;
            existingEvent.Date = updatedEvent.Date;
            existingEvent.Description = updatedEvent.Description;

            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEvent(int id)
    {
        try
        {
            var eventToDelete = _context.Events.Find(id);
            if (eventToDelete == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}