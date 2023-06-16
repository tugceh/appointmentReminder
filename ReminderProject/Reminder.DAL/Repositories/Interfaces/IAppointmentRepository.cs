using MongoDB.Bson;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<Appointment> GetByIdAsync(ObjectId objectId);
        Task<Appointment> GetByPatientIdAsync(ObjectId objectId);
        Task<List<Appointment>> GetAllAsync();
        Task<List<Appointment>> GetByDateAsync(DateTime date1, DateTime date2);
        Task<string> InsertAsync(Appointment entity);
    }
}
