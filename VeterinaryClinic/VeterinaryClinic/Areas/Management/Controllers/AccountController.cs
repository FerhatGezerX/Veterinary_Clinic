using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Areas.Management.Models;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Areas.Management.Controllers
{
    public class AccountController : Controller
    {
        VeterinaryDbContext db = new VeterinaryDbContext();
       
        public IActionResult Login()
        {
            ViewBag.Meesage = "";
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password && u.Status && u.Deleted == false && u.Role != RoleTypescs.User);


                if (user == null)
                {
                    ViewBag.Message = "Böyle bir kullanıcı bulunamadı";
                    return View(model);
                }
                var claims = new List<Claim>
                {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("Phone", user.Phone),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        //new Claim(ClaimTypes.Email, "email")
                        //new Claim("FullName", user.FullName),
                        //new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddHours(6),

                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                  new ClaimsPrincipal(claimsIdentity),
                                                  authProperties);
                ViewBag.Message = "Lütfen bilgilerinizi kontrol ediniz.";

                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }




        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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
