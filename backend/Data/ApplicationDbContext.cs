using Microsoft.EntityFrameworkCore;
using schoolApi.Models;

namespace schoolApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Classroom> Classroom { get; set; }
    public DbSet<SubjectMatter> SubjectMatter { get; set; }
    public DbSet<StudentSubjectMatter> StudentSubjectMatter { get; set; }
    public DbSet<CourseSubjectMatter> CourseSubjectMatter { get; set; }
    public DbSet<ClassroomSubjectMatter> ClassroomSubjectMatter { get; set; }
}
