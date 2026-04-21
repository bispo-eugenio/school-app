using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.StudentDtos;
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
        var studentModel = await _context.Student.FirstOrDefaultAsync(s => s.Id == id);

        if (studentModel == null)
            return studentModel;

        _context.Student.Remove(studentModel);
        await _context.SaveChangesAsync();

        return studentModel;
    }


    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Student.Include(s => s.StudentSubjectMatters).ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Student.Include(s => s.StudentSubjectMatters).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student> PostAsync(Student student)
    {

        await _context.Student.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> UpdateAsync(int id, UpdateStudentRequestDTO updateStudentRequest)
    {
        var studentModel = await _context.Student.FirstOrDefaultAsync(s => s.Id == id);

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
