using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class ClinicController : Controller {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: CourseController
        public ActionResult Index()
        {
            var courses = db.Clinics
                .Where(c => c.Deleted == false)
                .Include(x => x.Status).Include("Category")
                .ToList();
            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.TrainerId = new SelectList(db.Animals
                .Where(x => x.Deleted == false && x.Status), "Id", "FullName", null);
            ViewBag.CategoryId = new SelectList(db.Categories
                .Where(x => x.Deleted == false && x.Status), "Id", "Title", null);
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clinic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.Deleted = false;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    db.Clinics.Add(model);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.TrainerId = new SelectList(db.Employees
                .Where(x => x.Deleted == false && x.Status), "Id", "FullName", model.Animals);
                ViewBag.CategoryId = new SelectList(db.Categories
                    .Where(x => x.Deleted == false && x.Status), "Id", "Title", model.Id);
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = db.Clinics.Find(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrainerId = new SelectList(db.Clinics
              .Where(x => x.Deleted == false && x.Status), "Id", "FullName", Clinic.Equals);
            ViewBag.CategoryId = new SelectList(db.Categories
                .Where(x => x.Deleted == false && x.Status), "Id", "Title", Clinic.ReferenceEquals);

            return View(course);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clinic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editClinic = db.Clinics.Find(model.Id);
                    if (editClinic == null)
                    {
                        return View(model);
                    }
                    editClinic.UpdatedDate = DateTime.Now;
                    editClinic.UpdatedBy = 0;
                    editClinic.CreatedBy = model.CreatedBy;
                    editClinic.Deleted = model.Deleted;
                    editClinic.Status = model.Status;
                    editClinic.Email = model.Email;
                    editClinic.Address = model.Address;
                    editClinic.Animals = model.Animals;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Id = new SelectList(db.Animals
              .Where(x => x.Deleted == false && x.Status), "Id", "FullName", model.Employees);
                ViewBag.CategoryId = new SelectList(db.Categories
                    .Where(x => x.Deleted == false && x.Status), "Id", "Title", model.Animals);

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
