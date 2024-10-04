using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Controllers
{
    public class LectureController : Controller
    {
        VeterinaryDbContext db = new VeterinaryDbContext();
        public IActionResult Index()
        {
            var clinic = db.Employees
               .Include("Appointment").Include("Animal")
               .Where(c => c.Status && c.Deleted == false).ToList();
            return View(clinic);
        }

        public IActionResult Appointment()
        {
            var appointments = db.Appointments.Where(c => c.Status && c.Deleted == false)
                .ToList();
            return View(appointments);
        }

    }
}
