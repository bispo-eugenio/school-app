using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class CourseSubjectMatterRepository : ICourseSubjectMatterRepository
{
    private readonly ApplicationDbContext _context;
    public CourseSubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<CourseSubjectMatter>> GetAllAsync()
    {
        return await _context.CourseSubjectMatter.ToListAsync();
    }

    public async Task<CourseSubjectMatter?> GetByIdAsync(List<int>? dualId)
    {
        if (dualId == null)
            return null;

        return await _context.CourseSubjectMatter.FindAsync(dualId[0], dualId[1]);
    }

    public async Task<CourseSubjectMatter> PostAsync(CourseSubjectMatter courseSubjectMatter)
    {
        await _context.CourseSubjectMatter.AddAsync(courseSubjectMatter);
        await _context.SaveChangesAsync();

        return courseSubjectMatter;
    }
}
