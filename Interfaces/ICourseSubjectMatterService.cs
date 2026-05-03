using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseSubjectMatterService
{
    public Task<List<CourseSubjectMatter>>
    GetAll(CourseSubjectMatterQueryable query);
    public Task<CourseSubjectMatter?> GetById(List<int> dualId);
    public Task<CourseSubjectMatter> Create(CourseSubjectMatter course);
    public Task<CourseSubjectMatter?> Update(List<int> dualId,
    UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest);
    public Task<CourseSubjectMatter?> Delete(List<int> dualId);
}
