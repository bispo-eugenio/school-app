using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
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

    public async Task<CourseSubjectMatter?> DeleteAsync(List<int> dualId)
    {

        var courseSubjectMatterModel = await _context.CourseSubjectMatter.FindAsync(dualId[0], dualId[1]);

        if (courseSubjectMatterModel == null)
            return courseSubjectMatterModel;

        _context.CourseSubjectMatter.Remove(courseSubjectMatterModel);
        await _context.SaveChangesAsync();

        return courseSubjectMatterModel;
    }


    public async Task<List<CourseSubjectMatter>>
    GetAllAsync(CourseSubjectMatterQueryable query)
    {
        var courseSubjectMattersModel = _context.CourseSubjectMatter.AsQueryable();

        if (query.IsActived != null)
            courseSubjectMattersModel = courseSubjectMattersModel
            .Where(csm => csm.IsActived.Equals(query.IsActived));

        if (query.WorkloadHours != null
        && query.WorkloadHours >= 0)
            courseSubjectMattersModel = courseSubjectMattersModel
            .Where(csm => csm.WorkloadHours.Equals(query.WorkloadHours));

        if (query.Semester != null
        && query.Semester >= 0)
            courseSubjectMattersModel = courseSubjectMattersModel
            .Where(csm => csm.Semester.Equals(query.Semester));

        if (query.IsMandatory != null)
            courseSubjectMattersModel = courseSubjectMattersModel
            .Where(csm => csm.IsMandatory.Equals(query.IsMandatory));

        return await courseSubjectMattersModel.ToListAsync();
    }

    public async Task<CourseSubjectMatter?> GetByIdAsync(List<int> dualId)
    {
        return await _context.CourseSubjectMatter.FindAsync(dualId[0], dualId[1]);
    }

    public async Task<CourseSubjectMatter> PostAsync(CourseSubjectMatter courseSubjectMatter)
    {
        await _context.CourseSubjectMatter.AddAsync(courseSubjectMatter);
        await _context.SaveChangesAsync();

        return courseSubjectMatter;
    }

    public async Task<CourseSubjectMatter?> UpdateAsync(List<int> dualId, UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest)
    {
        var courseSubjectMatterModel = await _context.CourseSubjectMatter.FindAsync(dualId[0], dualId[1]);

        if (courseSubjectMatterModel == null)
            return courseSubjectMatterModel;

        courseSubjectMatterModel.CourseId = updateCourseSubjectMatterRequest.CourseId;
        courseSubjectMatterModel.SubjectMatterId = updateCourseSubjectMatterRequest.SubjectMatterId;
        await _context.SaveChangesAsync();

        return courseSubjectMatterModel;
    }

}
