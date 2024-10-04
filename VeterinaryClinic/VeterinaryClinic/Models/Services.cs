using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Services : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
