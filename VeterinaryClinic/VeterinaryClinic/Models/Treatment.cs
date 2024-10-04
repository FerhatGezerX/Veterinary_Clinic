using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Treatment : BaseEntity {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string TreatmentName { get; set; }


        [Required]
        public DateTime TreatmentDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
