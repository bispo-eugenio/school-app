using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using dotenv.net;
using schoolApi.Interfaces;
using schoolApi.Repository;
using schoolApi;
using Newtonsoft.Json;
using FluentValidation;
using schoolApi.Helpers.Validators;
using schoolApi.Services;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

//Doc
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//Database
builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    options.UseMySQL($"""
        Server={Environment.GetEnvironmentVariable("SERVER")};
        User ID={Environment.GetEnvironmentVariable("USERID")};
        Password={Environment.GetEnvironmentVariable("PASSWORD")};
        Database={Environment.GetEnvironmentVariable("DATABASE")}
    """);
});

//Newtonsoft
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

});

//Controllers
builder.Services.AddControllers();

//Builder Validations
builder.Services.AddValidatorsFromAssemblyContaining<CourseValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TeacherValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ClassroomValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ClassroomSubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CourseSubjectMatterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StudentSubjectMatterValidator>();

//Builder Repositories
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentSubjectMatterRepository, StudentSubjectMatterRepository>();
builder.Services.AddScoped<ICourseSubjectMatterRepository, CourseSubjectMatterRepository>();
builder.Services.AddScoped<IClassroomSubjectMatterRepository, ClassroomSubjectMatterRepository>();
builder.Services.AddScoped<ISubjectMatterRepository, SubjectMatterRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

//Builder Services
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
