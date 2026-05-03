using schoolApi.DTOs.CourseDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseRepository
{
    public Task<List<Course>> GetAllAsync(CourseQueryable query);
    public Task<Course?> GetByIdAsync(int id);
    public Task<List<SubjectMatter>> GetSubjectMattersByCourse(int id);
    public Task<Course> PostAsync(Course course);
    public Task<Course?> UpdateAsync(int id, UpdateCourseRequestDTO updateCourseRequest);
    public Task<Course?> DeleteAsync(int id);
}
