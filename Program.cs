using Microsoft.EntityFrameworkCore;
using withlogin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add session services
builder.Services.AddSession();

// Add MVC services
builder.Services.AddControllersWithViews();

// Register the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add session middleware
app.UseSession();  // This is the key change to enable session

// Configure routing
app.UseRouting();

app.UseAuthorization();

// Define the default route for MVC
app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.Run();
