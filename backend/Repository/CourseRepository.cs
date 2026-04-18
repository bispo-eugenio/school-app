using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;
    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Course.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Course.FindAsync(id);
    }

    public async Task<Course> PostAsync(Course course)
    {

        await _context.Course.AddAsync(course);
        await _context.SaveChangesAsync();

        return course;
    }
}
