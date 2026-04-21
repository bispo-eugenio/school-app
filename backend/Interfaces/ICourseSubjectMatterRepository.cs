using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseSubjectMatterRepository
{
    public Task<List<CourseSubjectMatter>> GetAllAsync();
    public Task<CourseSubjectMatter?> GetByIdAsync(List<int>? dualId);
    public Task<CourseSubjectMatter> PostAsync(CourseSubjectMatter course);
}
