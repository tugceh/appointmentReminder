using Microsoft.Extensions.Hosting;
using Quartz;
using Reminder.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class ScheduleService : IScheduleService, IJob
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogService _logService;
        private Timer? _timer = null;

        public ScheduleService(IAppointmentService appointmentService, ILogService logService)
        {
            _appointmentService = appointmentService;
            _logService = logService;
        }

        public void ControlAppointments()
        {
            _logService.AddInfo("Schedule service running.", "Reminder is starting");
            _appointmentService.RemindAppointments();
        }
        public Task Execute(IJobExecutionContext context)
        {
            ControlAppointments();
            return Task.FromResult(true);
        }
        
    }
}
