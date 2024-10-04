using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class TreatmentController : Controller
    {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: TreatmentController
        public ActionResult Index()
        {
            var treatment = db.Treatments.Where(c => c.Deleted == false)
               .ToList();

            return View(treatment);
        }

        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            var treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return RedirectToAction("Index");
            }
            return View(treatment);
        }

        // GET: TreatmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Treatment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Treatments.Add(model);
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

        // GET: TreatmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Treatment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editTreatment = db.Treatments.Find(model.Id);
                    if (editTreatment == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    editTreatment.TreatmentDate = model.TreatmentDate;
                    editTreatment.Description = model.Description;
                    editTreatment.TreatmentName = model.TreatmentName;
                    editTreatment.CreatedBy = model.CreatedBy;
                    editTreatment.Status = model.Status;
                    editTreatment.UpdatedBy = 0;
                    editTreatment.UpdatedDate = DateTime.Now;
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

        // GET: TreatmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

        // POST: TreatmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var treatment = db.Treatments.Find(id);
                if (treatment == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                treatment.Deleted = true;
                treatment.UpdatedDate = DateTime.Now;
                treatment.UpdatedBy = 0;
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
