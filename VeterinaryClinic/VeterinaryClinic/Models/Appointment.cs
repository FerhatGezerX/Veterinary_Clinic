using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinaryClinic.Models
{
    public class Appointment : BaseEntity {
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Reason { get; set; }
        [StringLength(128)]
        public string Notes { get; set; }
       
        public virtual Animal Animal { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
