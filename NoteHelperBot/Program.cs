var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
