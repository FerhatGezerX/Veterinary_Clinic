using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        VeterinaryDbContext db = new VeterinaryDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = new VeterinaryDbContext();
        }
        
        public IActionResult Index()
        {
            var pages  = db.Pageies.FirstOrDefault();
            return View(pages);
        }

        public IActionResult About()
        {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }

        public IActionResult Contact()
        {
            var contact = db.Contacts.FirstOrDefault();
            return View(contact);
        }

         public IActionResult Services()
         {
            var services = db.Servicess.FirstOrDefault();
            return View(services);
         }

		public IActionResult Blog()
		{
			var blog = db.Blogs.FirstOrDefault();
			return View(blog);
		}

        public IActionResult Pages()
        {
            var pages = db.Pageies.FirstOrDefault();
            return View(pages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
