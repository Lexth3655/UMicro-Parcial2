
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using UMicro.Core;
using UMicro.Core.Services;
using UMicro.Domain.Interfaces;
using UMicro.Persistence;
using UMicro.Persistence.Data;
using UMicro.Persistence.Repository;
using UMicro.Persistence.Unit;

var builder = WebApplication.CreateBuilder(args);
//Inyecto al controlador del repositorio
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILibroRepository, LibrosRepository>();
builder.Services.AddScoped<IEditorialRepository, EditorialRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
     sqlOptions => sqlOptions.MigrationsAssembly("UMicro.Persistence")));

// Registro de UnitOfWork y Repositorio de Autor
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();

// Otros servicios
builder.Services.AddScoped<AutorService>();

// Añadir servicios de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UMicro API", Version = "v1" });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCore();
builder.Services.AddPersistence();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Habilitar Swagger

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UMicro API V1");
    c.RoutePrefix = string.Empty; // Swagger en la raíz
});

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
