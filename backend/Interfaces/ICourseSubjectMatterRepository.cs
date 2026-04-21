using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseSubjectMatterRepository
{
    public Task<List<CourseSubjectMatter>> GetAllAsync();
    public Task<CourseSubjectMatter?> GetByIdAsync(List<int> dualId);
    public Task<CourseSubjectMatter> PostAsync(CourseSubjectMatter course);
    public Task<CourseSubjectMatter?> UpdateAsync(List<int> dualId, UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest);
    public Task<CourseSubjectMatter?> DeleteAsync(List<int> dualId);
}
