using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Repositories;
using ClubManagementAPI.Data;
using ClubManagementAPI.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<ApplicationDbContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IBookingRepository>(provider => new BookingRepository(connectionString));

// Register Repositories
builder.Services.AddScoped<IGymClassRepository, GymClassRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ISearchBookingRepository, SearchBookingRepository>();

// Register Services
builder.Services.AddScoped<IGymClassService, GymClassService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ISearchBookingService, SearchBookingService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();





























