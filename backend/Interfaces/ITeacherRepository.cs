using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ITeacherRepository
{
    public Task<List<Teacher>> GetAll();
    public Task<Teacher?> GetByIdAsync(int id);
    public Task<Teacher> PostAsync(Teacher teacher);
}
