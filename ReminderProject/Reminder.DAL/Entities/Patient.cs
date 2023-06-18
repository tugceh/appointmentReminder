using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Entities
{
    public class Patient : BaseEntity
    {
        public Patient()
        {

        }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public string MedicalHistory { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
