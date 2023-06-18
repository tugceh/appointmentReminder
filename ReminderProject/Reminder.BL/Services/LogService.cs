using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Entities;
using Reminder.DAL.Enums;
using Reminder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<string> AddError(string shortMessage, string fullMessage)
        {
            Log log = new()
            {
                Type = LogType.Error,
                ShortMessage = shortMessage,
                FullMessage = fullMessage
            };
            return await _logRepository.InsertAsync(log);
        }

        public async Task<string> AddInfo(string shortMessage, string fullMessage)
        {
            Log log = new()
            {
                Type = LogType.Info,
                ShortMessage = shortMessage,
                FullMessage = fullMessage
            };
            return await _logRepository.InsertAsync(log);
        }

        public async Task<string> AddWarning(string shortMessage, string fullMessage)
        {
            Log log = new()
            {
                Type = LogType.Warning,
                ShortMessage = shortMessage,
                FullMessage = fullMessage
            };
            return await _logRepository.InsertAsync(log);
        }
    }
}
