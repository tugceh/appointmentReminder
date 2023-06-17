using Reminder.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Entities
{
    public class Log : BaseEntity
    {
        public LogType Type { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
    }
}
