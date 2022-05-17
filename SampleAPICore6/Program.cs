using Microsoft.EntityFrameworkCore;
using SampleAPICore6.Data;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddDbContext<DbContextCinema>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SampleCinemaDB"));
builder.Services.AddScoped<IMovie, MovieAPI>();
builder.Services.AddScoped<IUser, UserAPI>();
builder.Services.AddScoped<IReservation, ReservationAPI>();




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
