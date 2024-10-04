using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class User : BaseEntity {
        [Key]
        public int Id { get; set; }
        [StringLength(25)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength (20)]
        public string IdentityNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public RoleTypescs Role { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
