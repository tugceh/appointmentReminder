using MongoDB.Driver;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.DataContext
{
    public static class ContextSeed
    {
        public static async Task SeedPateintAsync(IMongoCollection<Patient> patients)
        {
            bool exist = patients.Find(p => true).Any();

            if (exist)
                await patients.DeleteManyAsync(p => true);

            await patients.InsertManyAsync(Patients());
        }

        public static async Task SeedAppointmentAsync(IMongoCollection<Patient> patients, IMongoCollection<Appointment> appointments)
        {
            bool exist = appointments.Find(p => true).Any();

            if (exist)
                await appointments.DeleteManyAsync(p => true);

            await appointments.InsertManyAsync(Appointments(patients));
        }

        #region Helper Methods

        static List<Patient> Patients() =>
            new()
            {
                new Patient { Name = "Tuğçe Şen", IDNumber = "30141185696", Phone="05544851785", Email="tugcehsen@gmail.com", Address="Batıkent", MedicalHistory="Kan Alım"},
                new Patient { Name = "Hilal Şen", IDNumber = "20185185696", Phone="05444851785", Email="tugcehilalsen@hotmail.com", Address="Batıkent", MedicalHistory="Serum" },
            };

        static List<Appointment> Appointments(IMongoCollection<Patient> patients)
        {
            Patient patient = patients.Find(Builders<Patient>.Filter.Eq(f => f.Name, "Tuğçe Şen")).FirstOrDefault();

            return new()
            {
                new Appointment {AppointmentDate = DateTime.Now, Department="İç hastalıkları", Patient = patient, PatientId = patient.Id},
                new Appointment {AppointmentDate = DateTime.Now, Department="Dermatoloji", Patient = patient, PatientId = patient.Id}
            };
        }
        #endregion
    }
}
