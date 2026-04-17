using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentSubjectMatterRepository
{
    public Task<List<StudentSubjectMatter>> GetAll();
    public Task<StudentSubjectMatter?> GetByIdAsync(int id);
    public Task<StudentSubjectMatter> PostAsync(StudentSubjectMatter studentSubjectMatter);
}
