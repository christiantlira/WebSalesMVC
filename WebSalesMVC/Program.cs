using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using WebSalesMVC.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebSalesMVCContext") ?? throw new InvalidOperationException("Connection string 'WebSalesMVCContext' not found.");

builder.Services.AddDbContext<WebSalesMVCContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>(); //Criei a classe no Data antes de adicionar aqui
builder.Services.AddScoped<SellerService>();

var app = builder.Build();


// Equivalente ao "seedingService.Seed()" do Configure do professor
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
