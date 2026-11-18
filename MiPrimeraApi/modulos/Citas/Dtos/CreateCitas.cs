using System.ComponentModel.DataAnnotations;

namespace MiPrimeraApi.modulos.Citas.Dtos;

public class CreateAppointmentDto {
  [Required(ErrorMessage = "El nombre del paciente es requerido")]
  [StringLength(120, ErrorMessage = "El nombre del paciente no puede superar los 120 caracteres")]
  public required string PatientName { get; set; }

  [Required(ErrorMessage = "El nombre del doctor es requerido")]
  [StringLength(120, ErrorMessage = "El nombre del doctor no puede superar los 120 caracteres")]
  public required string DoctorName { get; set; }

  [Required(ErrorMessage = "La fecha de la cita es requerida")]
  public required DateTime StartsAt { get; set; }

  [Required(ErrorMessage = "El motivo es requerido")]
  [StringLength(300, ErrorMessage = "El motivo no puede superar los 300 caracteres")]
  public required string Reason { get; set; }
}