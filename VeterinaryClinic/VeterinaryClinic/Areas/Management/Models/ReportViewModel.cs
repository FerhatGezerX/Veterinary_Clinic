using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Models {
    public class ReportViewModel {
        public List<Animal> Animals { get; set; }
        public List<Franchise> Franchises { get; set; }
        public List<User> Users { get; set; }
    }
}
