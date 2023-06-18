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
    public class PatientRepository : IPatientRepository
    {
        private readonly IContext dataContext;

        public PatientRepository(IOptions<DatabaseSetting> settings) =>
            dataContext = new DataContext.Context(settings.Value);

        public async Task<Patient> GetByIdAsync(ObjectId objectId) =>
             await dataContext.Patients.Find(Builders<Patient>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

        public async Task<Patient> GetByIDNumberAsync(string idNumber) =>
             await dataContext.Patients.Find(Builders<Patient>.Filter.Eq(f => f.IDNumber, idNumber)).FirstOrDefaultAsync();

        public async Task<List<Patient>> GetAllAsync() =>
             await dataContext.Patients.Find(Builders<Patient>.Filter.Where(f => !f.Deleted)).ToListAsync();

        public async Task<string> InsertAsync(Patient entity)
        {
            await dataContext.Patients.InsertOneAsync(entity);
            return entity.Id.ToString();
        }
    }
}
