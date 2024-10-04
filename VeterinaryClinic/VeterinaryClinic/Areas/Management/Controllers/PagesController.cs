using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers {
    [Authorize(Roles = "Admin,Developer")]
    public class PagesController : Controller {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: MainPageController
        public ActionResult Index()
        {
            Pages pages = db.Pageies.FirstOrDefault();
            return View(pages);
        }

        // GET: MainPageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
