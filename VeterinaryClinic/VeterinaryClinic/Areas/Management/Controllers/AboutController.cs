using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Models;
using VeterinaryClinic.Utils;

namespace VeterinaryClinic.Areas.Management.Controllers
{
   
    public class AboutController : Controller
    {
        
        private readonly IWebHostEnvironment _environment;
        VeterinaryDbContext db = new VeterinaryDbContext();

        public AboutController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        // GET: AboutController
        public ActionResult Index()
        {
            About about = db.Abouts.FirstOrDefault();
            return View(about);
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            var about = db.Abouts.Find(id);
            if (about == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(About model, IFormFile? img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var about = db.Abouts.Find(model.Id);
                    if (about != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    if (img != null)
                    {
                        await ImageUploader.DeleteImageAsync(_environment, about.ImageUrl);
                        about.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
                    }
                    about.Title = model.Title;
                    about.Description = model.Description;
                    about.UpdatedDate = model.UpdatedDate;
                    about.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
                    about.Status = model.Status;
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
    }
}
