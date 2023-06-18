using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Reminder.BL.Services;
using Reminder.BL.Services.Interfaces;
using Reminder.DAL.Settings;
using ReminderProject.API.Extensions;
using Reminder.BL.Extensions;
using Reminder.DAL.Extensions;
using Reminder.DAL.DataContext;
using Reminder.BL.Dto;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.Configure<DatabaseSetting>(configuration.GetSection(nameof(DatabaseSetting)));


builder.Services.AddSingleton<IDatabaseSetting>(sp => sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);

builder.Services.AddDAL();
builder.Services.AddBL();
//builder.Services.AddHostedService<ScheduleService>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    var jobKey = new JobKey("ScheduleService");
    q.AddJob<ScheduleService>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ScheduleService-trigger").WithSimpleSchedule(x => x
                .RepeatForever()
                .WithIntervalInMinutes(5)
                ));
        //.WithCronSchedule("1/5 * * * * ?"));

});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reminder.API", Version = "v1" });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reminder.API v1"));
}

var logService = app.Services.GetRequiredService<ILogService>();
app.ConfigureExceptionHandler(logService);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
