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

    public async Task<List<StudentSubjectMatter>> GetAllAsync()
    {
        return await _context.StudentSubjectMatter.ToListAsync();
    }

    public async Task<StudentSubjectMatter?> GetByIdAsync(List<int>? dualId)
    {
        if (dualId == null)
            return null;
        return await _context.StudentSubjectMatter.FindAsync(dualId[0], dualId[1]);
    }

    public async Task<StudentSubjectMatter> PostAsync(StudentSubjectMatter studentSubjectMatter)
    {

        await _context.StudentSubjectMatter.AddAsync(studentSubjectMatter);
        await _context.SaveChangesAsync();

        return studentSubjectMatter;
    }
}
