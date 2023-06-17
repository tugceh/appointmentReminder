using MongoDB.Bson;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services.Interfaces
{
    public interface IAppointmentService : IService
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetById(ObjectId Id);
        Task<List<Appointment>> GetByPatientId(ObjectId Id);
        Task<List<Appointment>> GetByDate(DateTime date1, DateTime date2);
        Task<string> InsertAsync(Appointment appointment);
        Task<string> RemindAppointments();
    }
}
