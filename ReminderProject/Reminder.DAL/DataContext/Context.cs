using MongoDB.Driver;
using Reminder.DAL.Entities;
using Reminder.DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.DataContext
{
    public class Context : IContext
    {
        public Context(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Patients = database.GetCollection<Patient>(nameof(Patient));
            MedicalHistories = database.GetCollection<MedicalHistory>(nameof(MedicalHistory));
            Appointments = database.GetCollection<Appointment>(nameof(Appointment));
        }

        public IMongoCollection<Patient> Patients { get; set; }
        public IMongoCollection<MedicalHistory> MedicalHistories { get; set; }
        public IMongoCollection<Appointment> Appointments { get; set; }
    }
}
