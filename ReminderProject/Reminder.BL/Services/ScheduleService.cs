using Microsoft.Extensions.Hosting;
using Reminder.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class ScheduleService : IScheduleService, IHostedService
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogService _logService;
        private Timer? _timer = null;

        public ScheduleService(IAppointmentService appointmentService, ILogService logService)
        {
            _appointmentService = appointmentService;
            _logService = logService;
        }

        public void ControlAppointments(object state)
        {
            _logService.AddInfo("Schedule service running.", "Reminder is starting");
            _appointmentService.RemindAppointments();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // timer repeates call to ControlAppointments every 15 minutes.
            _timer = new Timer(ControlAppointments,null,TimeSpan.Zero,TimeSpan.FromSeconds(15)
            );

            return Task.CompletedTask;
        }

        /// Call the Stop async method if required from within the app.
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
