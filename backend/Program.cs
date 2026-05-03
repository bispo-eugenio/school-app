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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using schoolApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

//Doc
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Demo API",
            Version = "v1"
        });

    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Description = "Please enter valid token.",
            BearerFormat = "JWT",
        });

    options.AddSecurityRequirement(
        document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });

});

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

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (
            Encoding.UTF8.GetBytes($"{builder.Configuration["JWT:SigningKey"]}")
        ),
    };

});

builder.Services.AddIdentityCore<AppUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
    options.Password.RequiredUniqueChars = 4;
    options.Password.RequireLowercase = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager();

builder.Services.AddAuthorization();

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
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
