namespace MiPrimeraApi.modulos.Citas.Entidades;

public class Appointment {
  public Guid Uuid { get; set; }
  public int Id { get; set; }
  public required string PatientName { get; set; }
  public required string DoctorName { get; set; }
  public DateTime StartsAt { get; set; }
  public required string Reason { get; set; }
}