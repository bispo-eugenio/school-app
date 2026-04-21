using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using dotenv.net;
using schoolApi.Interfaces;
using schoolApi.Repository;
using schoolApi;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    options.UseMySQL(ApplicationDbContext._connectionString);
});
builder.Services.AddControllers();
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentSubjectMatterRepository, StudentSubjectMatterRepository>();
builder.Services.AddScoped<ICourseSubjectMatterRepository, CourseSubjectMatterRepository>();
builder.Services.AddScoped<ISubjectMatterRepository, SubjectMatterRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
