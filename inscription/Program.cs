using inscription.Infraestructures.Contexts;
using Microsoft.EntityFrameworkCore;
using inscription.Models;
using inscription.App.Interfases;
using inscription.App.Implemets;
using inscription.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de la conexión a la base de datos
builder.Services.AddDbContext<InscriptionsContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);


builder.Services.AddScoped<ICareer, CareerRepository>(); // Repositorio como implementación de ICareer
builder.Services.AddTransient<CareerService>(); // Servicio como implementación de ICareer



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
