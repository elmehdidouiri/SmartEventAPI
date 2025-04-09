using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEvent.API.Data;
using SmartEvent.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartEvent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }

        // Récupérer toutes les inscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            try
            {
                return Ok(await _context.Registrations.Include(r => r.User).Include(r => r.Event).ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Récupérer une inscription par ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            try
            {
                var registration = await _context.Registrations.Include(r => r.User).Include(r => r.Event).FirstOrDefaultAsync(r => r.Id == id);
                if (registration == null)
                {
                    return NotFound($"Registration with ID {id} not found.");
                }
                return Ok(registration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Inscrire un utilisateur à un événement
        [HttpPost]
        public async Task<IActionResult> RegisterToEvent([FromBody] RegistrationDto dto)
        {
            try
            {
                var existing = await _context.Registrations
                    .FirstOrDefaultAsync(r => r.UserId == dto.UserId && r.EventId == dto.EventId);

                if (existing != null)
                {
                    return BadRequest("Utilisateur déjà inscrit à cet événement.");
                }

                var user = await _context.Users.FindAsync(dto.UserId);
                if (user == null)
                {
                    return BadRequest($"User with ID {dto.UserId} not found.");
                }

                var eventItem = await _context.Events.FindAsync(dto.EventId);
                if (eventItem == null)
                {
                    return BadRequest($"Event with ID {dto.EventId} not found.");
                }

                var registration = new Registration
                {
                    UserId = dto.UserId,
                    EventId = dto.EventId,
                    RegisteredAt = DateTime.UtcNow
                };

                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRegistration), new { id = registration.Id }, registration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}