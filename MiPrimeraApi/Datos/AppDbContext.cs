namespace MiPrimeraApi.Datos;

using MiPrimeraApi.modulos.Citas.Entidades;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
  public DbSet<Appointment> Appointments => Set<Appointment>();

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
  }
}