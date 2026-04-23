using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.SubjectMatterDtos;
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
        var subjectMatterModel = await _context.SubjectMatter.FirstOrDefaultAsync(s => s.Id == id);

        if (subjectMatterModel == null)
            return subjectMatterModel;

        _context.SubjectMatter.Remove(subjectMatterModel);
        await _context.SaveChangesAsync();

        return subjectMatterModel;

    }


    public async Task<List<SubjectMatter>> GetAllAsync()
    {
        return await _context.SubjectMatter.Include(s => s.StudentSubjectMatters).Include(s => s.CourseSubjectMatters).Include(s => s.Classroom).ToListAsync();
    }

    public async Task<SubjectMatter?> GetByIdAsync(int id)
    {
        return await _context.SubjectMatter.Include(s => s.StudentSubjectMatters).Include(s => s.CourseSubjectMatters).Include(s => s.Classroom).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<SubjectMatter> PostAsync(SubjectMatter subjectMatter)
    {

        await _context.SubjectMatter.AddAsync(subjectMatter);
        await _context.SaveChangesAsync();

        return subjectMatter;
    }

    public async Task<SubjectMatter?> UpdateAsync(int id, UpdateSubjectMatterRequestDTO updateSubjectMatterRequest)
    {
        var subjectMatterModel = await _context.SubjectMatter.FirstOrDefaultAsync(s => s.Id == id);

        if (subjectMatterModel == null)
            return subjectMatterModel;

        subjectMatterModel.Name = updateSubjectMatterRequest.Name;
        subjectMatterModel.Day = updateSubjectMatterRequest.Day;
        subjectMatterModel.StartedAt = updateSubjectMatterRequest.StartedAt;
        subjectMatterModel.EndedAt = updateSubjectMatterRequest.EndedAt;
        subjectMatterModel.Details = updateSubjectMatterRequest.Details;
        subjectMatterModel.TeacherId = updateSubjectMatterRequest.TeacherId;
        await _context.SaveChangesAsync();

        return subjectMatterModel;
    }

}
