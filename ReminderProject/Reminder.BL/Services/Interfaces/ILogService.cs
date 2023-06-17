using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services.Interfaces
{
    public interface ILogService
    {
        Task<string> AddInfo(string shortMessage, string fullMessage);
        Task<string> AddWarning(string shortMessage, string fullMesage);
        Task<string> AddError(string shortMessage, string fullMesage);
    }
}
