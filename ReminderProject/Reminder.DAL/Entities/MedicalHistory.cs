using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Entities
{
    public class MedicalHistory : BaseEntity
    {
        public MedicalHistory()
        {

        }
        public string MedicalName { get; set; }
        public bool Deleted { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PatientId { get; set; }

        [BsonIgnore]
        public Patient Patient { get; set; }
    }
}
