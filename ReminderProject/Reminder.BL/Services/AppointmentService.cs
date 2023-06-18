using MongoDB.Bson;
using Reminder.BL.Dto;
using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Entities;
using Reminder.DAL.Repositories;
using Reminder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmailSender _emailSender;
        private readonly IPatientRepository _patientRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IEmailSender emailSender, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _emailSender = emailSender;
            _patientRepository = patientRepository;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return appointments;
        }

        public async Task<Appointment> GetById(ObjectId Id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(Id);
            return appointment;
        }

        public async Task<List<Appointment>> GetByPatientId(ObjectId Id)
        {
            var appointments = await _appointmentRepository.GetByPatientIdAsync(Id);
            return appointments;
        }

        public async Task<List<Appointment>> GetByDate(DateTime date1, DateTime date2)
        {
            var appointments = await _appointmentRepository.GetByDateAsync(date1, date2);
            return appointments;
        }

        public async Task<string> InsertAsync(AppointmentDto appointment)
        {
            var patient = _patientRepository.GetByIDNumberAsync(appointment.PatientIdNumber).Result;
            if (patient != null)
            {
                Appointment appointmentModel = new Appointment()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    Department = appointment.Department,
                    Deleted = false,
                    PatientId = patient.Id
                };
                var result = await _appointmentRepository.InsertAsync(appointmentModel);
                if (!string.IsNullOrEmpty(result))
                {
                    return "Appointment was added successfully.";
                }
                return "Appointment was not added successfully.";
            }
            else
                return"Patient was not found!!";
        }

        public async Task<string> RemindAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAsync();
                appointments = appointments.Where(i => i.AppointmentDate >= DateTime.Now).ToList();
                foreach (var appointment in appointments)
                {
                    var patient = _patientRepository.GetByIdAsync(appointment.PatientId).Result;
                    var message = new Message(new string[] { patient.Email}, "Appointment Remind", $"Hello {patient.Name}, you have appointment on {appointment.AppointmentDate} date. This email is reminder.");
                    await _emailSender.SendEmailAsync(message);
                }
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
