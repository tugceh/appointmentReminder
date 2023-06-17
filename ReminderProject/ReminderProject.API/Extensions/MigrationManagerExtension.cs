using Reminder.DAL.DataContext;

namespace ReminderProject.API.Extensions
{
    public static class MigrationManagerExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    IContext context = scope.ServiceProvider.GetRequiredService<IContext>();

                    ContextSeed.SeedPateintAsync(context.Patients).Wait();
                    ContextSeed.SeedAppointmentAsync(context.Patients, context.Appointments).Wait();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Database migration failed! Message: {ex.Message}");
                }
            }

            return host;
        }
    }
}
