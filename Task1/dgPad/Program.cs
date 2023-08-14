using dgPad.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sqlite"]);

});

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sqlite"]);

});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
});

builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllers();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();