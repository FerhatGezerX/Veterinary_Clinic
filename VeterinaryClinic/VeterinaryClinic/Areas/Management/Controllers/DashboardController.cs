using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VeterinaryClinic.Areas.Management.Models;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class DashboardController : Controller {
        VeterinaryDbContext db = new VeterinaryDbContext();
        public IActionResult Index()
        {
            //LINQ = https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/write-linq-queries

            DashboardViewModel model = new DashboardViewModel();
            model.UserCount = db.Users.Count(r =>
                                            r.Role == VeterinaryClinic.Models.RoleTypescs.User
                                            && r.Deleted == false
                                            && r.Status);

            model.AnimalCount = db.Animals.Count(c =>
                                            c.Status
                                            && c.Deleted == false);

            model.EmployeeCount = db.Employees.Count(c =>
                                            c.Status
                                            && c.Deleted == false);

            model.FranchiseCount = db.Franchises.Count(c =>
                                            c.Status
                                            && c.Deleted == false);

            model.LastCreatedUser = db.Users
                .OrderByDescending(o => o.CreatedDate)
                .FirstOrDefault();

            model.LastCreatedUsers = db.Users
                .OrderByDescending(o => o.CreatedDate)
                //.Skip(5)
                .Take(5);

                return View(model);
            

        }
    }
}
