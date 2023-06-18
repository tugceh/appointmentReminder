using MongoDB.Bson;
using Reminder.BL.Dto;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services.Interfaces
{
    public interface IPatientService : IService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(ObjectId Id);
        Task<Patient> GetPatientByIdNumber(string idNumber);
        Task<string> InsertAsync(PateintDto patient);
    }
}
