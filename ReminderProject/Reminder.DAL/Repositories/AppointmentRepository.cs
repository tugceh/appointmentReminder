using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Reminder.DAL.DataContext;
using Reminder.DAL.Entities;
using Reminder.DAL.Repositories.Interfaces;
using Reminder.DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IContext dataContext;

        public AppointmentRepository(IOptions<DatabaseSetting> settings) =>
            dataContext = new DataContext.Context(settings.Value);

        public async Task<Appointment> GetByIdAsync(ObjectId objectId) =>
             await dataContext.Appointments.Find(Builders<Appointment>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

        public async Task<Appointment> GetByPatientIdAsync(ObjectId objectId) =>
            await dataContext.Appointments.Find(Builders<Appointment>.Filter.Eq(f => f.PatientId, objectId)).FirstOrDefaultAsync();
        public async Task<List<Appointment>> GetAllAsync() =>
             await dataContext.Appointments.Find(Builders<Appointment>.Filter.Where(f => !f.Deleted)).ToListAsync();

        public async Task<List<Appointment>> GetByDateAsync(DateTime date1, DateTime date2) =>
            await dataContext.Appointments.Find(Builders<Appointment>.Filter.Where(f => f.AppointmentDate >= date1 && f.AppointmentDate <= date2)).ToListAsync();

        public async Task<string> InsertAsync(Appointment entity)
        {
            await dataContext.Appointments.InsertOneAsync(entity);
            return entity.Id.ToString();
        }
    }
}
