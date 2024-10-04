using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class UserController : Controller {
        VeterinaryDbContext db = new VeterinaryDbContext();
        // GET: UserController
        public ActionResult Index()
        {
			var user = db.Users.Include(x=>x.Animals).ToList();
			return View(user);
		}
        
       
        
    }
}
