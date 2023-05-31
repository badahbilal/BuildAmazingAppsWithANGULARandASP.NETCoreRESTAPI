using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Mappings;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// This line of code adds the CORS (Cross-Origin Resource Sharing) services to the dependency injection container.
// CORS is a mechanism that allows resources (e.g., APIs) to be requested from a different domain or origin.
builder.Services.AddCors();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Inject DbConetxt into the service container
builder.Services.AddDbContext<StudentAdminDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb")));

// This line of code registers the implementation of the IStudentRepository interface, SqlStudentRepository, as a scoped service in the dependency injection container.
// Scoped services are created once per client request and are shared within the same request scope.
builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
// This line of code configures the CORS policy for the application using the app.UseCors method.
// The CORS policy allows any header and any HTTP method to be used in the requests.
// Only requests originating from "http://localhost:4200" are allowed to access the resources.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));


app.UseAuthorization();

app.MapControllers();

app.Run();
