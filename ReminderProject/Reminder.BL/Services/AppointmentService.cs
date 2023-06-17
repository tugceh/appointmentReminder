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
        public AppointmentService(IAppointmentRepository appointmentRepository, IEmailSender emailSender)
        {
            _appointmentRepository = appointmentRepository;
            _emailSender = emailSender;
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

        public async Task<string> InsertAsync(Appointment appointment)
        {
            var result = await _appointmentRepository.InsertAsync(appointment);
            return result;
        }

        public async Task<string> RemindAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAsync();
                foreach (var appointment in appointments)
                {
                    var message = new Message(new string[] { appointment.Patient.Email}, "Appointment Remind", $"Hello {appointment.Patient.Name}, you have appointment on {appointment.AppointmentDate} date. This email is reminder.");
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
