using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {

        }
        public DateTime AppointmentDate { get; set; }
        public string Department{ get; set; }
        public bool Deleted { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PatientId { get; set; }

        //[BsonIgnore]
        //public Patient Patient { get; set; }
    }
}
