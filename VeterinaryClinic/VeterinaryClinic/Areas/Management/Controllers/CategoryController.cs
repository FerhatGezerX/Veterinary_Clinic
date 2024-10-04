using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Models;
using VeterinaryClinic.Utils;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class CategoryController : Controller
    {
        //dependency injection
        private readonly IWebHostEnvironment _environment;
        VeterinaryDbContext db = new VeterinaryDbContext();
        public CategoryController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

		public ActionResult Index()
		{
			var categories = db.Categories
				.Where(c => c.Deleted == false)
				.ToList();
			return View(categories);
		}


		// GET: CategoryController/Details/5
		public ActionResult Details(int id)
        {
            var category = db.Categories
                .Include("Animals")
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = true;
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = 0;
                    model.Deleted = false;
                    db.Categories.Add(model);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = db.Categories
               .Find(id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category model, IFormFile? img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = db.Abouts.Find(model.Id);
                    if (category != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    if (img != null)
                    {
                        await ImageUploader.DeleteImageAsync(_environment, category.ImageUrl);
                        category.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
                    }
                    category.Title = model.Title;
                    category.Description = model.Description;
                    category.UpdatedDate = model.UpdatedDate;
                    category.UpdatedBy = 0;
                    category.Status = model.Status;
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
        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
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
