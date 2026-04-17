using schoolApi.Models;

namespace schoolApi;

public interface ISubjectMatterRepository
{
    public Task<List<SubjectMatter>> GetAll();
    public Task<SubjectMatter?> GetByIdAsync(int id);
    public Task<SubjectMatter> PostAsync(SubjectMatter subjectMatter);
}
