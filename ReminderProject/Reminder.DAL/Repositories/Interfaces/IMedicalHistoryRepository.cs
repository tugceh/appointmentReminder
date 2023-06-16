using MongoDB.Bson;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Repositories.Interfaces
{
    public interface IMedicalHistoryRepository: IRepository<MedicalHistory>
    {
        Task<MedicalHistory> GetByIdAsync(ObjectId objectId);
        Task<MedicalHistory> GetByPatientIdAsync(ObjectId objectId);
        Task<List<MedicalHistory>> GetAllAsync();
        Task<string> InsertAsync(MedicalHistory entity);
    }
}
