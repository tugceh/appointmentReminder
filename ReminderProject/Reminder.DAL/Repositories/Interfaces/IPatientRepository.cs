using MongoDB.Bson;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Repositories.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetByIdAsync(ObjectId objectId);
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIDNumberAsync(string idNumber);
        Task<string> InsertAsync(Patient entity);
    }
}
