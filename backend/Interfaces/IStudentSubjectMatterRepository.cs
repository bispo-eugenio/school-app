using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentSubjectMatterRepository
{
    public Task<List<StudentSubjectMatter>> GetAllAsync();
    public Task<StudentSubjectMatter?> GetByIdAsync(List<int>? dualId);
    public Task<StudentSubjectMatter> PostAsync(StudentSubjectMatter studentSubjectMatter);
}
