using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Franchise : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string WorkingTime { get; set; }
    }
}
