using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: AppointmentController
        public ActionResult Index() {
            var appointment = db.Appointments.Where(c => c.Deleted == false)
               .ToList();

            return View(appointment);
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id) {
            var appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment model) {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Appointments.Add(model);
                    db.SaveChanges();
                    //MailSender.SendMail(model.FullName, new List<string> { model.Email });
                    return RedirectToAction(nameof(Index));


                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id) {
            var appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment model) {
            try
            {
                if (ModelState.IsValid)
                {
                    var editAppointment = db.Appointments.Find(model.Id);
                    if (editAppointment == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    editAppointment.AppointmentDate = model.AppointmentDate;
                    editAppointment.Reason = model.Reason;
                    editAppointment.StartTime = model.StartTime;
                    editAppointment.EndTime = model.EndTime;
                    editAppointment.Status = model.Status;
                    editAppointment.UpdatedBy = 0;
                    editAppointment.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id) {
            var appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // POST: AppointmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            try
            {
                var appointment = db.Appointments.Find(id);
                if (appointment == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                appointment.Deleted = true;
                appointment.UpdatedDate = DateTime.Now;
                appointment.UpdatedBy = 0;
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
