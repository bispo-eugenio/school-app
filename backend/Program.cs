using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using dotenv.net;
using schoolApi.Interfaces;
using schoolApi.Repository;
using schoolApi;
using Scalar.AspNetCore;
using Newtonsoft.Json;
using FluentValidation;
using schoolApi.Helpers.Validators;
using schoolApi.Services;

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
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

});
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CourseValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TeacherValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ClassroomValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ClassroomSubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CourseSubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StudentSubjectMatterValidator>();

builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentSubjectMatterRepository, StudentSubjectMatterRepository>();
builder.Services.AddScoped<ICourseSubjectMatterRepository, CourseSubjectMatterRepository>();
builder.Services.AddScoped<IClassroomSubjectMatterRepository, ClassroomSubjectMatterRepository>();
builder.Services.AddScoped<ISubjectMatterRepository, SubjectMatterRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectMatterService, SubjectMatterService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IClassroomSubjectMatterService, ClassroomSubjectMatterService>();
builder.Services.AddScoped<ICourseSubjectMatterService, CourseSubjectMatterService>();
builder.Services.AddScoped<IStudentSubjectMatterService, StudentSubjectMatterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi();
    app.MapScalarApiReference("/docs");
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
