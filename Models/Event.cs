using System.ComponentModel.DataAnnotations;

namespace SmartEvent.API.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Registration> Registrations { get; set; }


    }
}
