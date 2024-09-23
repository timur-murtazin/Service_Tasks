
using Microsoft.EntityFrameworkCore;
using Service_Tasks.BLL.Services;
using Service_Tasks.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<TasksService>();


//builder.Services.AddDbContext<DBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(AppMappingService));

string connectionString = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddDbContext<WebApiDbContext>(options => options.UseNpgsql(connectionString));

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

app.Run();
