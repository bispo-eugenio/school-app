using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.CourseDtos;
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

    public async Task<Course?> DeleteAsync(int id)
    {
        var courseModel = await _context.Course
        .FirstOrDefaultAsync(c => c.Id == id);

        if (courseModel == null)
            return courseModel;

        _context.Course.Remove(courseModel);
        await _context.SaveChangesAsync();

        return courseModel;
    }


    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Course
        .Include(c => c.Students)
        .Include(c => c.CourseSubjectMatters)
        .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Course
        .Include(c => c.Students)
        .Include(c => c.CourseSubjectMatters)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<SubjectMatter>>
    GetSubjectMattersByCourse(int id)
    {
        return await _context.SubjectMatter
            .Where(sm => sm.CourseSubjectMatters
                .Any(csm => csm.CourseId == id))
        .Include(sm => sm.CourseSubjectMatters)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<Course> PostAsync(Course course)
    {

        await _context.Course.AddAsync(course);
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<Course?> UpdateAsync(int id,
    UpdateCourseRequestDTO updateCourseRequest)
    {
        var courseModel = await _context.Course
        .FirstOrDefaultAsync(c => c.Id == id);

        if (courseModel == null)
            return courseModel;

        courseModel.Name = updateCourseRequest.Name;
        courseModel.Details = updateCourseRequest.Details;
        await _context.SaveChangesAsync();

        return courseModel;
    }

}
