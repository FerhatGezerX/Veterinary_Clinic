using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Blog : BaseEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
