using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Home : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<string> Services { get; set; }

    }
}
