using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
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

    public async Task<List<Student>> GetAll()
    {
        return await _context.Student.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Student.FindAsync(id);
    }

    public async Task<Student> PostAsync(Student student)
    {

        await _context.Student.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }
}
