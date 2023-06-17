using MongoDB.Bson;
using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Entities;
using Reminder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            return patients;
        }

        public async Task<Patient> GetPatientById(ObjectId Id)
        {
            var patient = await _patientRepository.GetByIdAsync(Id);
            return patient;
        }

        public async Task<Patient> GetPatientByIdNumber(string idNumber)
        {
            var patient = await _patientRepository.GetByIDNumberAsync(idNumber);
            return patient;
        }

        public async Task<string> InsertAsync(Patient patient)
        {
            var result = await _patientRepository.InsertAsync(patient);
            return result;
        }
    }
}
