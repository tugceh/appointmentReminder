using MongoDB.Driver;
using Reminder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.DataContext
{
    public interface IContext
    {
        IMongoCollection<Patient> Patients { get; }
        IMongoCollection<Appointment> Appointments { get; }
        IMongoCollection<Log> Logs { get; }
    }
}
