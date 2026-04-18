using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentRepository
{
    public Task<List<Student>> GetAllAsync();
    public Task<Student?> GetByIdAsync(int id);
    public Task<Student> PostAsync(Student student);
}
