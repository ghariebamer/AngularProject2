using WebApplication1;
using WebApplication1.interfaces;
using WebApplication1.Models;
using WebApplication1.Repositry;
using NLog;
using Logger_Service;
using LoggerService;

var builder = WebApplication.CreateBuilder(args);

// Add Logger
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Connection>(dbconnectcion =>
dbconnectcion.connectionstring = builder.Configuration.GetConnectionString("ConnectionDefault"));

//builder.Services.AddTransient<GlobalExceptionMiddlewareExtensions>();
builder.Services.AddCors(option =>
{
    option.AddPolicy("corsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddScoped<IDepartment, DepartmentRepo>();
builder.Services.AddScoped<IEmployee, EmployeeRepo>();

// Register Logger To DI 

builder.Services.AddSingleton<ILoggerManager, LoggerManger>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Logging Error 
app.UseCors("corsPolicy");
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<GlobalExceptionMiddlewareExtensions>();

app.MapControllers();

app.Run();
