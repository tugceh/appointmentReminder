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
    public class LogRepository : ILogRepository
    {
        private readonly IContext dataContext;

        public LogRepository(IOptions<DatabaseSetting> settings) =>
            dataContext = new DataContext.Context(settings.Value);

        public async Task<List<Log>> GetAllAsync() =>
             await dataContext.Logs.Find(l => true).ToListAsync();

        public async Task<Log> GetByIdAsync(ObjectId objectId) =>
             await dataContext.Logs.Find(Builders<Log>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();

        public async Task<string> InsertAsync(Log entity)
        {
            await dataContext.Logs.InsertOneAsync(entity);
            return entity.Id.ToString();
        }
    }
}
