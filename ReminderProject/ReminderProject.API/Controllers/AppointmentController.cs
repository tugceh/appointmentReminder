using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Reminder.BL.Services;
using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Entities;

namespace ReminderProject.API.Controllers
{
    [Route("reminder/api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService) =>
            _appointmentService = appointmentService;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _appointmentService.GetAllAppointments());

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(ObjectId id) =>
            Ok(await _appointmentService.GetById(id));

        [HttpGet("getbypatientid/{id}")]
        public async Task<IActionResult> GetByPatientId(ObjectId id) =>
            Ok(await _appointmentService.GetByPatientId(id));

        [HttpPost("insert")]
        public async Task<IActionResult> InsertAppointment(Appointment appointment) =>
            Ok(await _appointmentService.InsertAsync(appointment));

        [HttpGet("startReminder")]
        public async Task<IActionResult> StartReminder() =>
            Ok(await _appointmentService.RemindAppointments());
    }
}
