using schoolApi.DTOs.TeacherDtos;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ITeacherRepository
{
    public Task<List<Teacher>> GetAllAsync();
    public Task<Teacher?> GetByIdAsync(int id);
    public Task<Teacher> PostAsync(Teacher teacher);
    public Task<Teacher?> UpdateAsync(int id, UpdateTeacherRequestDTO updateTeacherRequest);
    public Task<Teacher?> DeleteAsync(int id);
}
