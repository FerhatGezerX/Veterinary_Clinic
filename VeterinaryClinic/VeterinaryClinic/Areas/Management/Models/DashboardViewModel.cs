using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Models
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }
        public int AnimalCount { get; set; }
        public int TreatmentCount { get; set; }
        public int TodaysAppointments { get; set; }
        public int EmployeeCount {  get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int FranchiseCount { get; set; }
        public int NewPatients { get; set; }
        public int ActivePatients { get; set; }
        public int Revenue { get; set; }
        public User? LastCreatedUser { get; set; }

        public IEnumerable<User?> LastCreatedUsers { get; set; }


        public List<AppointmentViewModel> RecentAppointments { get; set; }
        public List<DashboardViewModel> MostActivePatients { get; set; }


    }
}
