using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services.Interfaces
{
    public interface IScheduleService
    {
        //Task StartAsync(CancellationToken cancellationToken);
        //Task StopAsync(CancellationToken cancellationToken);
        Task Execute(IJobExecutionContext context);
    }
}
