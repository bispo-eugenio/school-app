using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using schoolApi.Data;
using schoolApi.DTOs.StudentDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;
    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> DeleteAsync(int id)
    {
        var studentModel = await _context.Student
        .FirstOrDefaultAsync(s => s.Id == id);

        if (studentModel == null)
            return studentModel;

        _context.Student.Remove(studentModel);
        await _context.SaveChangesAsync();

        return studentModel;
    }


    public async Task<List<Student>> GetAllAsync(StudentQueryable query)
    {
        var studentModel = _context.Student
        .Include(s => s.StudentSubjectMatters)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
            studentModel = studentModel.Where(s => s.Name.Contains(query.Name));

        if (query.Age != null && query.Age.GetType() == typeof(int)
        && query.Age >= 18)
            studentModel = studentModel.Where(s => s.Age.Equals(query.Age));

        if (query.CourseId != null && query.CourseId.GetType() == typeof(int)
        && query.CourseId >= 1)
            studentModel = studentModel.Where(s => s.CourseId.Equals(query.CourseId));

        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                studentModel = query.IsDescending
                ? studentModel.OrderByDescending(s => s.Name)
                : studentModel.OrderBy(s => s.Name);
            }
            if (query.SortBy.Equals("Age", StringComparison.OrdinalIgnoreCase))
            {
                studentModel = query.IsDescending
                ? studentModel.OrderByDescending(s => s.Age)
                : studentModel.OrderBy(s => s.Age);
            }
            if (query.SortBy.Equals("CourseId", StringComparison.OrdinalIgnoreCase))
            {
                studentModel = query.IsDescending
                ? studentModel.OrderByDescending(s => s.CourseId)
                : studentModel.OrderBy(s => s.CourseId);
            }
        }

        var pageNum = (query.Page - 1) * query.PageSize;

        return await studentModel
        .Skip(pageNum)
        .Take(query.PageSize)
        .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Student
        .Include(s => s.StudentSubjectMatters)
        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<SubjectMatter>>
    GetSubjectMattersByStudent(int id)
    {
        return await _context.SubjectMatter
            .Where(sm => sm.StudentSubjectMatters
                .Any(ssm => ssm.StudentId == id))
        .Include(sm => sm.StudentSubjectMatters)
        .AsNoTracking()
        .ToListAsync();
    }


    public async Task<Student> PostAsync(Student student)
    {

        await _context.Student.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> UpdateAsync(int id,
     UpdateStudentRequestDTO updateStudentRequest)
    {
        var studentModel = await _context.Student
        .FirstOrDefaultAsync(s => s.Id == id);

        if (studentModel == null)
            return studentModel;

        studentModel.Name = updateStudentRequest.Name;
        studentModel.Cpf = updateStudentRequest.Cpf;
        studentModel.Age = updateStudentRequest.Age;
        studentModel.CourseId = updateStudentRequest.CourseId;
        await _context.SaveChangesAsync();

        return studentModel;
    }

}
