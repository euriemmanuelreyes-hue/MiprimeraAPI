using System.ComponentModel.DataAnnotations;

namespace MiPrimeraApi.modulos.Citas.Dtos;

public class PatchAppointmentDto {
  [MinLength(3, ErrorMessage = "El nombre del paciente debe tener al menos tres caracteres")]
  [MaxLength(120, ErrorMessage = "El nombre del paciente no puede superar los 120 caracteres")]
  public string? PatientName { get; set; }

  [MinLength(3, ErrorMessage = "El nombre del doctor debe tener al menos tres caracteres")]
  [MaxLength(120, ErrorMessage = "El nombre del doctor no puede superar los 120 caracteres")]
  public string? DoctorName { get; set; }

  public DateTime? StartsAt { get; set; }

  [MinLength(3, ErrorMessage = "El motivo debe tener al menos tres caracteres")]
  [MaxLength(300, ErrorMessage = "El motivo no puede superar los 300 caracteres")]
  public string? Reason { get; set; }
}