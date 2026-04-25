using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi;

public interface ISubjectMatterRepository
{
    public Task<List<SubjectMatter>> GetAllAsync();
    public Task<SubjectMatter?> GetByIdAsync(int id);
    public Task<List<Course>> GetCoursesBySubjectMatter(int id);
    public Task<List<Student>> GetStudentsBySubjectMatter(int id);
    public Task<SubjectMatter> PostAsync(SubjectMatter subjectMatter);
    public Task<SubjectMatter?> UpdateAsync(int id, UpdateSubjectMatterRequestDTO updateSubjectMatterRequest);
    public Task<SubjectMatter?> DeleteAsync(int id);
}
