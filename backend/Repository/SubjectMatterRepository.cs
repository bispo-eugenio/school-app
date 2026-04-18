using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.Models;

namespace schoolApi.Repository;

public class SubjectMatterRepository : ISubjectMatterRepository
{
    private readonly ApplicationDbContext _context;
    public SubjectMatterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubjectMatter>> GetAllAsync()
    {
        return await _context.SubjectMatter.ToListAsync();
    }

    public async Task<SubjectMatter?> GetByIdAsync(int id)
    {
        return await _context.SubjectMatter.FindAsync(id);
    }

    public async Task<SubjectMatter> PostAsync(SubjectMatter subjectMatter)
    {

        await _context.SubjectMatter.AddAsync(subjectMatter);
        await _context.SaveChangesAsync();

        return subjectMatter;
    }
}
