using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(opt =>
			{
				opt.LoginPath = "/Management/Account/Login/";
				opt.AccessDeniedPath = "/Management/Account/AccessDenied";
			});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
//Yorum sat?r?
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  //Kimlik Do?rulama
app.UseAuthorization();   //Yetki Do?rulama

app.UseEndpoints(endpoints => {

	endpoints.MapAreaControllerRoute(
	name: "Management",
	areaName: "Management",
	pattern: "Management/{controller=Dashboard}/{action=Index}/{id?}"
	);

	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller}/{action}"
	);

	endpoints.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
