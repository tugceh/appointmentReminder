using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Settings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
