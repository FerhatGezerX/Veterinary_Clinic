namespace VeterinaryClinic.Areas.Management.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
