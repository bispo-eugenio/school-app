using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;
    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAll()
    {
        return await _context.Teacher.ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teacher.FindAsync(id);
    }

    public async Task<Teacher> PostAsync(Teacher teacher)
    {

        await _context.Teacher.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return teacher;
    }
}
