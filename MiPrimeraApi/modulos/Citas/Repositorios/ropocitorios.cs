using MiPrimeraApi.Datos;
using MiPrimeraApi.modulos.Citas.Entidades;

namespace MiPrimeraApi.modulos.Citas.Repositorios;

public class AppointmentRepository(AppDbContext dbContext) {
  public readonly AppDbContext _dbContext = dbContext;

  public List<Appointment> FindAll() {
    return _dbContext.Appointments.ToList();
  }

  public void Create(Appointment appointment) {
    _dbContext.Add(appointment);
    _dbContext.SaveChanges();
  }

  public Appointment? FindOne(Guid uuid) {
    return _dbContext.Appointments.FirstOrDefault((a) => a.Uuid == uuid);
  }

  public bool Delete(Guid uuid) {
    var appointment = _dbContext.Appointments.FirstOrDefault((a) => a.Uuid == uuid);

    if (appointment is null) {
      return false;
    }

    _dbContext.Appointments.Remove(appointment);
    _dbContext.SaveChanges();

    return true;

  }

  public bool Patch(Guid uuid, string? patientName, string? doctorName, DateTime? startsAt, string? reason) {
    var appointment = _dbContext.Appointments.FirstOrDefault((a) => a.Uuid == uuid);

    if (appointment is null) {
      return false;
    }

    if (patientName is not null || doctorName is not null || startsAt is not null || reason is not null) {
      if (patientName is not null) {
        appointment.PatientName = patientName;
      }

      if (doctorName is not null) {
        appointment.DoctorName = doctorName;
      }

      if (startsAt is not null) {
        appointment.StartsAt = startsAt.Value;
      }

      if (reason is not null) {
        appointment.Reason = reason;
      }

      _dbContext.SaveChanges();
      return true;
    }

    return false;
  }

}