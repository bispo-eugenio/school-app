using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Repository;

public class SubjectMatterRepository : ISubjectMatterRepository
{
    private readonly ApplicationDbContext _context;
    public SubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SubjectMatter?> DeleteAsync(int id)
    {
        var subjectMatterModel = await _context.SubjectMatter
        .FirstOrDefaultAsync(s => s.Id == id);

        if (subjectMatterModel == null)
            return subjectMatterModel;

        _context.SubjectMatter.Remove(subjectMatterModel);
        await _context.SaveChangesAsync();

        return subjectMatterModel;

    }


    public async Task<List<SubjectMatter>> GetAllAsync(SubjectMatterQueryable query)
    {
        var subjectMatterModel = _context.SubjectMatter
        .Include(s => s.StudentSubjectMatters)
        .Include(s => s.CourseSubjectMatters)
        .Include(s => s.ClassroomSubjectMatters)
        .ThenInclude(csm => csm.Classroom)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
            subjectMatterModel = subjectMatterModel
            .Where(sm => sm.Name.Contains(query.Name));

        if (query.TeacherId != null
        && query.TeacherId.GetType() == typeof(int) && query.TeacherId >= 1)
            subjectMatterModel = subjectMatterModel
            .Where(s => s.TeacherId.Equals(query.TeacherId));


        return await subjectMatterModel.ToListAsync();

    }

    public async Task<SubjectMatter?> GetByIdAsync(int id)
    {
        return await _context.SubjectMatter
        .Include(s => s.StudentSubjectMatters)
        .Include(s => s.CourseSubjectMatters)
        .Include(s => s.ClassroomSubjectMatters)
        .ThenInclude(csm => csm.Classroom)
        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Course>> GetCoursesBySubjectMatter(int id)
    {
        return await _context.Course
            .Where(c => c.CourseSubjectMatters
                .Any(csm => csm.SubjectMatterId == id))
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<Student>> GetStudentsBySubjectMatter(int id)
    {
        return await _context.Student
            .Where(s => s.StudentSubjectMatters
                .Any(ssm => ssm.SubjectMatterId == id))
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<SubjectMatter> PostAsync(SubjectMatter subjectMatter)
    {

        await _context.SubjectMatter.AddAsync(subjectMatter);
        await _context.SaveChangesAsync();

        return subjectMatter;
    }

    public async Task<SubjectMatter?> UpdateAsync(int id,
    UpdateSubjectMatterRequestDTO updateSubjectMatterRequest)
    {
        var subjectMatterModel = await _context.SubjectMatter
        .FirstOrDefaultAsync(s => s.Id == id);

        if (subjectMatterModel == null)
            return subjectMatterModel;

        subjectMatterModel.Name = updateSubjectMatterRequest.Name;
        subjectMatterModel.Details = updateSubjectMatterRequest.Details;
        subjectMatterModel.TeacherId = updateSubjectMatterRequest.TeacherId;
        await _context.SaveChangesAsync();

        return subjectMatterModel;
    }

}
