using WebApplication1;
using WebApplication1.Repositry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Connection>(dbconnectcion =>
dbconnectcion.connectionstring = builder.Configuration.GetConnectionString("ConnectionDefault"));

builder.Services.AddCors(option =>
{
    option.AddPolicy("corsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddScoped<IDepartment, DepartmentRepo>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
