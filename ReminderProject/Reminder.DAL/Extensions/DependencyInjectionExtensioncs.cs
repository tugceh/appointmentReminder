using Microsoft.Extensions.DependencyInjection;
using Reminder.DAL.DataContext;
using Reminder.DAL.Repositories;
using Reminder.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DAL.Extensions
{
    public static class DependencyInjectionExtensioncs
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            services.AddScoped<IContext, Context>();

            services.AddScoped<IPatientRepository, PatientRepository>();
            //services.AddSingleton<ILogRepository, LogRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
