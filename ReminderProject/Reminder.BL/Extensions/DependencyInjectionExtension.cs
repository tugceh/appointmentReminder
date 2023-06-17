using Microsoft.Extensions.DependencyInjection;
using Reminder.BL.Services;
using Reminder.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddBL(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}
