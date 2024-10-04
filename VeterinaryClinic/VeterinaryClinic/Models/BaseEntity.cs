using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Models
{
    public class BaseEntity {

        [Required, DefaultValue(true)]
        public bool Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public bool? Deleted { get; set; }
    }
}
