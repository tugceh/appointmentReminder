using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Dto
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Department { get; set; }

        public string PatientIdNumber { get; set; }
    }
}
