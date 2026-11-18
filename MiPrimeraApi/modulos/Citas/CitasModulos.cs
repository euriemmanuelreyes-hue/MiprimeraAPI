using MiPrimeraApi.modulos.Citas.Repositorios;
using MiPrimeraApi.modulos.Citas.Servicios;

namespace MiPrimeraApi.modulos.Citas;

public static class CitasModule {
  public static IServiceCollection AddCitasModule(this IServiceCollection services) {

    services.AddScoped<AppointmentRepository>();
    services.AddScoped<AppointmentService>();

    return services;
  }
}