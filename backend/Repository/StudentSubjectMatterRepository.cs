using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class StudentSubjectMatterRepository : IStudentSubjectMatterRepository
{
    public readonly ApplicationDbContext _context;
    public StudentSubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentSubjectMatter>> GetAll()
    {
        return await _context.StudentSubjectMatter.ToListAsync();
    }

    public async Task<StudentSubjectMatter?> GetByIdAsync(int id)
    {
        return await _context.StudentSubjectMatter.FindAsync(id);
    }

    public async Task<StudentSubjectMatter> PostAsync(StudentSubjectMatter studentSubjectMatter)
    {

        await _context.StudentSubjectMatter.AddAsync(studentSubjectMatter);
        await _context.SaveChangesAsync();

        return studentSubjectMatter;
    }
}
