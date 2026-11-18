using MiPrimeraApi.Datos;
using MiPrimeraApi.modulos.Citas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCitasModule();

var app = builder.Build();

app.MapControllers();

app.Run("http://localhost:2000");
