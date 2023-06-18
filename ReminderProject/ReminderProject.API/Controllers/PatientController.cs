using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Entities;

namespace ReminderProject.API.Controllers
{
    [Route("reminder/api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) =>
            _patientService = patientService;


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _patientService.GetAllPatients());

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(ObjectId id) =>
            Ok(await _patientService.GetPatientById(id));

        [HttpGet("getbyidnumber/{idnumber}")]
        public async Task<IActionResult> GetByIdNumber(string idnumber) =>
            Ok(await _patientService.GetPatientByIdNumber(idnumber));

        [HttpPost("insert")]
        public async Task<IActionResult> InsertPatient(Patient patient) =>
            Ok(await _patientService.InsertAsync(patient));
    }
}
