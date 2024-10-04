using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Employee : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        public virtual Clinic Clinic { get; set; }
    }
}
