using schoolApi.DTOs.CourseDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseService
{
    public Task<List<Course>> GetAll(CourseQueryable query);
    public Task<Course?> GetById(int id);
    public Task<List<SubjectMatter>> GetSubjectMattersByCourse(int id);
    public Task<Course> Create(Course course);
    public Task<Course?> Update(int id, UpdateCourseRequestDTO updateCourseRequest);
    public Task<Course?> Delete(int id);
}
