
 
using MiPrimeraApi.modulos.Citas.Dtos;
using MiPrimeraApi.modulos.Citas.Entidades;
using MiPrimeraApi.modulos.Citas.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraApi.modulos.Citas.Controladores;

[ApiController]
[Route("/api/citas")]
public class AppointmentController(AppointmentService appointmentService) : ControllerBase
{
    private readonly AppointmentService _appointmentService = appointmentService;

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_appointmentService.FindAll());
    }

    [HttpGet("{uuid}")]
    public IActionResult FindOne(Guid uuid)
    {
        var appointment = _appointmentService.FindOne(uuid);

        if (appointment is null)
        {
            return NotFound(new { Message = "Cita no encontrada" });
        }

        return Ok(appointment);
    }

    [HttpPost]
    public IActionResult Create(CreateAppointmentDto appointmentDto)
    {
        var appointment = new Appointment
        {
            Uuid = Guid.NewGuid(),
            PatientName = appointmentDto.PatientName,
            DoctorName = appointmentDto.DoctorName,
            StartsAt = DateTime.SpecifyKind(
                appointmentDto.StartsAt,
                DateTimeKind.Utc
            ),
            Reason = appointmentDto.Reason
        };

        _appointmentService.Create(appointment);

        return CreatedAtAction(
            nameof(FindOne),
            new { uuid = appointment.Uuid },
            appointment
        );
    }

    [HttpDelete("{uuid}")]
    public IActionResult Delete(Guid uuid)
    {
        var deleted = _appointmentService.Delete(uuid);

        if (!deleted)
        {
            return NotFound(new { Message = "La cita no se pudo eliminar." });
        }

        return Ok();
    }

    [HttpPatch("{uuid}")]
    public IActionResult Patch(Guid uuid, PatchAppointmentDto patchDto)
    {
        if (patchDto.PatientName is null &&
            patchDto.DoctorName is null &&
            patchDto.StartsAt is null &&
            patchDto.Reason is null)
        {
            return BadRequest(new
            {
                Message = "Debes enviar al menos un campo para actualizar."
            });
        }

        var updated = _appointmentService.Patch(
            uuid,
            patchDto.PatientName,
            patchDto.DoctorName,
            patchDto.StartsAt.HasValue
                ? DateTime.SpecifyKind(patchDto.StartsAt.Value, DateTimeKind.Utc)
                : null,
            patchDto.Reason
        );

        if (!updated)
        {
            return NotFound(new { Message = "La cita no se pudo actualizar." });
        }

        return Ok();
    }
}