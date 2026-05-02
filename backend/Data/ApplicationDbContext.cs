using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schoolApi.Models;

namespace schoolApi.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Teacher",
                NormalizedName = "TEACHER"
            },
            new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
