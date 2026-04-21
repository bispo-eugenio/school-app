using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Interfaces;
using schoolApi.Models;
using schoolApi.Helpers;

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


    public async Task<List<StudentSubjectMatter>> GetAllAsync()
    {
        return await _context.StudentSubjectMatter.ToListAsync();
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
        studentSubjectMatterModel.RecordGradeOne = updateStudentSubjectMatterRequest.RecordGradeOne;
        studentSubjectMatterModel.RecordGradeTwo = updateStudentSubjectMatterRequest.RecordGradeTwo;
        studentSubjectMatterModel.RecordGradeTotal = MathExtensions.Average(
            [updateStudentSubjectMatterRequest.RecordGradeOne,
             updateStudentSubjectMatterRequest.RecordGradeTwo]);
        await _context.SaveChangesAsync();

        return studentSubjectMatterModel;
    }

}
