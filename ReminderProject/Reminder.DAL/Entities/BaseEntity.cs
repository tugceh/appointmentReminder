using MongoDB.Bson;
using Reminder.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
            CreatedAt = DateTime.UtcNow;
        }

        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
