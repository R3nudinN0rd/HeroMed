using HeroMed_API.DatabaseContext;
using HeroMed_API.Repositories.Employee;
using HeroMed_API.Repositories.Job;
using HeroMed_API.Repositories.Patient;
using HeroMed_API.Repositories.PatientEmployee;
using HeroMed_API.Repositories.Salon;
using HeroMed_API.Repositories.Section;
using HeroMed_API.Repositories.User;
using HeroMed_API.Validators;
using Microsoft.EntityFrameworkCore;
using TransferServices.OAuth2Email.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HeroMedContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region EntitiesServices
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientEmployeeRepository, PatientEmployeeRepository>();
#endregion

#region MicellaneousServices
builder.Services.AddScoped<ControllersInputsValidators>();
builder.Services.AddScoped<IEmailSenderRepository, EmailSenderRepository>();
#endregion

#region CORS Origins
var AllowOrigins = "AllowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod(); ;
                      });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
