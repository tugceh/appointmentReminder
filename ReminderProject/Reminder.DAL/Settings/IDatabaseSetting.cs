using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Settings
{
    public interface IDatabaseSetting
    {
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
