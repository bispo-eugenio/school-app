using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Interfaces;
using schoolApi.Models;
using schoolApi.Helpers;
using schoolApi.Helpers.QueryableObjects;

namespace schoolApi.Repository;

public class StudentSubjectMatterRepository : IStudentSubjectMatterRepository
{
    public readonly ApplicationDbContext _context;
    public StudentSubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentSubjectMatter?> DeleteAsync(List<int> dualId)
    {
        var studentSubjectMatterModel = await _context.StudentSubjectMatter.FindAsync(dualId[0], dualId[1]);

        if (studentSubjectMatterModel == null)
            return studentSubjectMatterModel;

        _context.StudentSubjectMatter.Remove(studentSubjectMatterModel);
        await _context.SaveChangesAsync();

        return studentSubjectMatterModel;

    }

    public async Task<List<StudentSubjectMatter>> GetAllAsync(StudentSubjectMatterQueryable query)
    {
        var studentSubjectMatterModels = _context.StudentSubjectMatter.AsQueryable();

        if (query.FirstGrade != null && query.FirstGrade.GetType() == typeof(decimal)
        && query.FirstGrade >= 0)
            studentSubjectMatterModels = studentSubjectMatterModels
            .Where(ssm => ssm.FirstGrade.Equals(query.FirstGrade));

        if (query.SecondGrade != null && query.SecondGrade.GetType() == typeof(decimal)
        && query.SecondGrade >= 0)
            studentSubjectMatterModels = studentSubjectMatterModels
            .Where(ssm => ssm.SecondGrade.Equals(query.SecondGrade));

        if (query.GradeTotal != null && query.GradeTotal.GetType() == typeof(decimal)
        && query.GradeTotal >= 0)
            studentSubjectMatterModels = studentSubjectMatterModels
            .Where(ssm => ssm.GradeTotal.Equals(query.GradeTotal));

        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("FirstGrade", StringComparison.OrdinalIgnoreCase))
                studentSubjectMatterModels = query.IsDescending
                ? studentSubjectMatterModels.OrderByDescending(ssm => ssm.FirstGrade)
                : studentSubjectMatterModels.OrderBy(ssm => ssm.FirstGrade);

            if (query.SortBy.Equals("SecondGrade", StringComparison.OrdinalIgnoreCase))
                studentSubjectMatterModels = query.IsDescending
                ? studentSubjectMatterModels.OrderByDescending(ssm => ssm.SecondGrade)
                : studentSubjectMatterModels.OrderBy(ssm => ssm.SecondGrade);

            if (query.SortBy.Equals("GradeTotal", StringComparison.OrdinalIgnoreCase))
                studentSubjectMatterModels = query.IsDescending
                ? studentSubjectMatterModels.OrderByDescending(ssm => ssm.GradeTotal)
                : studentSubjectMatterModels.OrderBy(ssm => ssm.GradeTotal);
        }

        var pageNum = (query.Page - 1) * query.PageSize;

        return await studentSubjectMatterModels
        .Skip(pageNum)
        .Take(query.PageSize)
        .ToListAsync();
    }

    public async Task<StudentSubjectMatter?> GetByIdAsync(List<int> dualId)
    {
        return await _context.StudentSubjectMatter.FindAsync(dualId[0], dualId[1]);
    }

    public async Task<StudentSubjectMatter> PostAsync(StudentSubjectMatter studentSubjectMatter)
    {

        await _context.StudentSubjectMatter.AddAsync(studentSubjectMatter);
        await _context.SaveChangesAsync();

        return studentSubjectMatter;
    }

    public async Task<StudentSubjectMatter?> UpdateAsync(List<int> dualId, UpdateStudentSubjectMatterRequestDTO updateStudentSubjectMatterRequest)
    {
        var studentSubjectMatterModel = await _context.StudentSubjectMatter.FindAsync(dualId[0], dualId[1]);

        if (studentSubjectMatterModel == null)
            return studentSubjectMatterModel;

        studentSubjectMatterModel.StudentId = updateStudentSubjectMatterRequest.StudentId;
        studentSubjectMatterModel.SubjectMatterId = updateStudentSubjectMatterRequest.SubjectMatterId;
        studentSubjectMatterModel.FirstGrade = updateStudentSubjectMatterRequest.FirstGrade;
        studentSubjectMatterModel.SecondGrade = updateStudentSubjectMatterRequest.SecondGrade;
        studentSubjectMatterModel.GradeTotal = MathExtensions.Average(
            [updateStudentSubjectMatterRequest.FirstGrade,
             updateStudentSubjectMatterRequest.SecondGrade]);
        await _context.SaveChangesAsync();

        return studentSubjectMatterModel;
    }

}
