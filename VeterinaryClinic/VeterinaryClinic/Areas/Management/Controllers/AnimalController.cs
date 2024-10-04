using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class AnimalController : Controller
    {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: AnimalController
        public ActionResult Index(int id) {
            var animals = db.Animals.Where(c => c.Deleted == false)
                .ToList();

            return View(animals);
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int id) {
            var animal = db.Animals.Find(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: AnimalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Animal model) {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Animals.Add(model);
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

        // GET: AnimalController/Edit/5
        public ActionResult Edit(int id) {
            var animal = db.Animals.Find(id);
            if (animal == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Animal model) {
            try
            {
                if (ModelState.IsValid)
                {
                    var editAnimal = db.Animals.Find(model.Id);
                    if (editAnimal == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    editAnimal.FullName = model.FullName;
                    editAnimal.Species = model.Species;
                    editAnimal.Breed = model.Breed;
                    editAnimal.Status = model.Status;
                    editAnimal.UpdatedBy = 0;
                    editAnimal.UpdatedDate = DateTime.Now;
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

        // GET: AnimalController/Delete/5
        public ActionResult Delete(int id) {
            var animal = db.Animals.Find(id);
            if (animal == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // POST: AnimalController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            try {
                var trainer = db.Animals.Find(id);
                if (trainer == null) {
                    return RedirectToAction(nameof(Index));
                }
                trainer.Deleted = true;
                trainer.UpdatedDate = DateTime.Now;
                trainer.UpdatedBy = 0;
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
