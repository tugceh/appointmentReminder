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
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {

        private readonly IContext dataContext;

        public MedicalHistoryRepository(IOptions<DatabaseSetting> settings) =>
            dataContext = new DataContext.Context(settings.Value);

        public async Task<MedicalHistory> GetByIdAsync(ObjectId objectId) =>
             await dataContext.MedicalHistories.Find(Builders<MedicalHistory>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

        public async Task<MedicalHistory> GetByPatientIdAsync(ObjectId objectId) =>
            await dataContext.MedicalHistories.Find(Builders<MedicalHistory>.Filter.Eq(f => f.PatientId, objectId)).FirstOrDefaultAsync();
        public async Task<List<MedicalHistory>> GetAllAsync() =>
             await dataContext.MedicalHistories.Find(Builders<MedicalHistory>.Filter.Where(f => !f.Deleted)).ToListAsync();

        public async Task<string> InsertAsync(MedicalHistory entity)
        {
            await dataContext.MedicalHistories.InsertOneAsync(entity);
            return entity.Id.ToString();
        }
    }
}
