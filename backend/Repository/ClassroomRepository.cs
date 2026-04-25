using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
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

    public async Task<Classroom?> DeleteAsync(int id)
    {
        var classroomModel = await _context.Classroom.FirstOrDefaultAsync(c => c.Id == id);

        if (classroomModel == null)
            return classroomModel;

        _context.Classroom.Remove(classroomModel);
        await _context.SaveChangesAsync();

        return classroomModel;
    }


    public async Task<List<Classroom>> GetAllAsync(ClassroomQueryable query)
    {
        var classroomModel = _context.Classroom.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
            classroomModel = classroomModel.Where(c => c.Name.Contains(query.Name));

        return await classroomModel.ToListAsync();

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

    public async Task<Classroom?> UpdateAsync(int id, UpdateClassroomRequestDTO updateClassroomRequest)
    {
        var classroomModel = await _context.Classroom.FirstOrDefaultAsync(c => c.Id == id);

        if (classroomModel == null)
            return classroomModel;

        classroomModel.Name = updateClassroomRequest.Name;
        classroomModel.SubjectMatterId = updateClassroomRequest.SubjectMatterId;
        await _context.SaveChangesAsync();

        return classroomModel;
    }

}
