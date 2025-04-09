using Microsoft.AspNetCore.Mvc;
using SmartEvent.API.Models;
using SmartEvent.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartEvent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Récupérer tous les utilisateurs  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                if (users == null || !users.Any())
                {
                    return NoContent(); // Si aucun utilisateur n'est trouvé  
                }
                return Ok(users); // Retourner la liste des utilisateurs  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Erreur serveur interne  
            }
        }

        // Récupérer un utilisateur par ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(); // Retourner 404 si l'utilisateur n'est pas trouvé
                }
                return Ok(user); // Retourner l'utilisateur trouvé
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Erreur serveur interne
            }
        }

        // Créer un nouvel utilisateur
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null"); // Si les données sont nulles
            }

            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser); // Retourner l'utilisateur créé
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Erreur serveur interne
            }
        }

        // Mettre à jour un utilisateur
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
          
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound(); // Si l'utilisateur n'est pas trouvé
                }

                var updated = await _userService.UpdateUserAsync(user);
                if (!updated)
                {
                    return StatusCode(500, "Failed to update user"); // Si la mise à jour a échoué
                }
                return NoContent(); // Si la mise à jour a été effectuée correctement
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Erreur serveur interne
            }
        }

        // Supprimer un utilisateur
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deleted = await _userService.DeleteUserAsync(id);
                if (!deleted)
                {
                    return NotFound(); // Si l'utilisateur à supprimer n'est pas trouvé
                }
                return NoContent(); // Si la suppression a réussi
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Erreur serveur interne
            }
        }
    }
}
