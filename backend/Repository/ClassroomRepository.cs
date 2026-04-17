using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Repository;

public class ClassroomRepository : IClassroomRepository
{
    private readonly ApplicationDbContext _context;
    public ClassroomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Classroom>> GetAll()
    {
        return await _context.Classroom.ToListAsync();
    }

    public async Task<Classroom?> GetByIdAsync(int id)
    {
        return await _context.Classroom.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Classroom> PostAsync(Classroom classroom)
    {
        await _context.Classroom.AddAsync(classroom);
        await _context.SaveChangesAsync();

        return classroom;
    }

}
