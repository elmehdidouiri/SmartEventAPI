using System.ComponentModel.DataAnnotations;

namespace SmartEvent.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<Registration>? Registrations { get; set; }

    }
}
