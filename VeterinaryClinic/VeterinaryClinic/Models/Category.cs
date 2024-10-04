using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class Category : BaseEntity {
        public Category()
        {
            this.Animals = new HashSet<Animal>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
