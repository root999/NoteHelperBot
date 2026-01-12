using Microsoft.EntityFrameworkCore;
using NoteHelperBot.AppService.Interfaces;
using NoteHelperBot.AppService.Impls;
using NoteHelperBot.Infrastructure;
using NoteHelperBot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Load optional secret configuration file if mounted at runtime (e.g. Docker volume)
builder.Configuration.AddJsonFile("appsettings.secret.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

// Infrastructure & application DI registrations
// Register DbContext. For development and containerized runs we default to an in-memory DB
// to avoid requiring external DB providers. Change to a real provider in production.
builder.Services.AddDbContext<MessageRecordDbContext>(options => options.UseInMemoryDatabase("NoteHelperBot"));

builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IIntentService, IntentService>();
builder.Services.AddScoped<IMessageService, MessageService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// If running as a test host, the test project will call into the app without starting the
// real listener. Only run when executed as the application entrypoint.
if (Environment.GetCommandLineArgs().Length == 0 || Environment.GetCommandLineArgs().Length > 0)
{
    app.Run();
}

// Expose a method for WebApplicationFactory in tests to create the app without starting it.
namespace NoteHelperBot
{
    public partial class Program { }
}
