using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinaryClinic.Models
{
    public class Owner : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public string FullName { get; set; }
        [StringLength(128)]
        public string Address { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
       
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
