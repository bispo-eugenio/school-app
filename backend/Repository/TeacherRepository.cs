using Microsoft.EntityFrameworkCore;
using schoolApi.Data;
using schoolApi.DTOs.TeacherDtos;
using schoolApi.Helpers.QueryableObjects;
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

    public async Task<Teacher?> DeleteAsync(int id)
    {
        var teacherModel = await _context.Teacher
        .FirstOrDefaultAsync(t => t.Id == id);

        if (teacherModel == null)
            return teacherModel;

        _context.Teacher.Remove(teacherModel);
        await _context.SaveChangesAsync();

        return teacherModel;
    }


    public async Task<List<Teacher>> GetAllAsync(TeacherQueryable query)
    {
        var teacherModels = _context.Teacher
        .Include(t => t.SubjectMatters)
        .ThenInclude(s => s.Classroom)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
            teacherModels = teacherModels.Where(t => t.Name.Contains(query.Name));

        if (query.Age != null && query.Age.GetType() == typeof(int)
        && query.Age >= 18)
            teacherModels = teacherModels.Where(t => t.Age.Equals(query.Age));

        return await teacherModels.ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teacher
        .Include(t => t.SubjectMatters)
        .ThenInclude(s => s.Classroom)
        .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Teacher> PostAsync(Teacher teacher)
    {

        await _context.Teacher.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return teacher;
    }

    public async Task<Teacher?> UpdateAsync(int id,
    UpdateTeacherRequestDTO updateTeacherRequest)
    {
        var teacherModel = await _context.Teacher
        .FirstOrDefaultAsync(t => t.Id == id);

        if (teacherModel == null)
            return teacherModel;

        teacherModel.Name = updateTeacherRequest.Name;
        teacherModel.Cpf = updateTeacherRequest.Cpf;
        teacherModel.Age = updateTeacherRequest.Age;
        await _context.SaveChangesAsync();

        return teacherModel;
    }

}
