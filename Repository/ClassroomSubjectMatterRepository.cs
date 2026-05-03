using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class ClassroomSubjectMatterRepository : IClassroomSubjectMatterRepository
{
    private ApplicationDbContext _context;
    public ClassroomSubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ClassroomSubjectMatter?> DeleteAsync(List<int> dualId)
    {
        var classroomSubjectMatter = await _context.ClassroomSubjectMatter
        .FindAsync(dualId[0], dualId[1]);

        if (classroomSubjectMatter == null)
            return classroomSubjectMatter;

        _context.ClassroomSubjectMatter.Remove(classroomSubjectMatter);
        await _context.SaveChangesAsync();

        return classroomSubjectMatter;
    }

    public async Task<List<ClassroomSubjectMatter>>
    GetAllAsync(ClassroomSubjectMatterQueryable query)
    {
        var classroomSubjectMatterModel = _context.ClassroomSubjectMatter
        .Include(csm => csm.Classroom)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Day))
            classroomSubjectMatterModel = classroomSubjectMatterModel
            .Where(sm => sm.Day.Contains(query.Day));

        if (query.StartedAt != null)
            classroomSubjectMatterModel = classroomSubjectMatterModel
            .Where(sm => sm.StartedAt.Equals(query.StartedAt));

        if (query.EndedAt != null)
            classroomSubjectMatterModel = classroomSubjectMatterModel
            .Where(sm => sm.EndedAt.Equals(query.EndedAt));

        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Day", StringComparison.OrdinalIgnoreCase))
                classroomSubjectMatterModel = query.IsDescending ?
                classroomSubjectMatterModel.OrderByDescending(csm => csm.Day)
                : classroomSubjectMatterModel.OrderBy(csm => csm.Day);

            if (query.SortBy.Equals("StartedAt", StringComparison.OrdinalIgnoreCase))
                classroomSubjectMatterModel = query.IsDescending ?
                classroomSubjectMatterModel.OrderByDescending(csm => csm.StartedAt)
                : classroomSubjectMatterModel.OrderBy(csm => csm.StartedAt);

            if (query.SortBy.Equals("EndedAt", StringComparison.OrdinalIgnoreCase))
                classroomSubjectMatterModel = query.IsDescending ?
                classroomSubjectMatterModel.OrderByDescending(csm => csm.EndedAt)
                : classroomSubjectMatterModel.OrderBy(csm => csm.EndedAt);
        }

        var pageNum = (query.Page - 1) * query.PageSize;

        return await classroomSubjectMatterModel
        .Skip(pageNum)
        .Take(query.PageSize)
        .ToListAsync();
    }

    public async Task<ClassroomSubjectMatter?> GetByIdAsync(List<int> dualId)
    {
        var classroomSubjectMatter = await _context.ClassroomSubjectMatter
        .Include(csm => csm.Classroom)
        .Where(csm => csm.ClassroomId == dualId[0]
        && csm.SubjectMatterId == dualId[1])
        .FirstOrDefaultAsync();

        if (classroomSubjectMatter == null)
            return classroomSubjectMatter;

        return classroomSubjectMatter;
    }

    public async Task<ClassroomSubjectMatter> PostAsync(ClassroomSubjectMatter course)
    {
        await _context.ClassroomSubjectMatter.AddAsync(course);
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<ClassroomSubjectMatter?> UpdateAsync(List<int> dualId, UpdateClassroomSubjectMatterRequestDTO updateClassroomSubjectMatterRequest)
    {
        var classroomSubjectMatterModel = await _context.ClassroomSubjectMatter
        .FindAsync(dualId[0], dualId[1]);

        if (classroomSubjectMatterModel == null)
            return classroomSubjectMatterModel;

        classroomSubjectMatterModel.Day = updateClassroomSubjectMatterRequest.Day;
        classroomSubjectMatterModel.StartedAt = updateClassroomSubjectMatterRequest.StartedAt;
        classroomSubjectMatterModel.EndedAt = updateClassroomSubjectMatterRequest.EndedAt;
        classroomSubjectMatterModel.Details = updateClassroomSubjectMatterRequest.Details;
        await _context.SaveChangesAsync();

        return classroomSubjectMatterModel;
    }

}
