using FluentValidation;
using schoolApi.DTOs.CourseDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class CourseService : ICourseService
{
    private readonly IValidator<Course> _validator;
    private readonly ICourseRepository _courseRepos;
    public CourseService(ICourseRepository courseRepo,
    IValidator<Course> validator)
    {
        _courseRepos = courseRepo;
        _validator = validator;
    }

    public async Task<Course> Create(Course course)
    {
        var check = _validator.Validate(course);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _courseRepos.PostAsync(course);
    }

    public async Task<Course?> Delete(int id)
    {
        return await _courseRepos.DeleteAsync(id);
    }

    public async Task<List<Course>> GetAll(CourseQueryable query)
    {
        return await _courseRepos.GetAllAsync(query);
    }

    public async Task<Course?> GetById(int id)
    {
        return await _courseRepos.GetByIdAsync(id);
    }

    public async Task<List<SubjectMatter>> GetSubjectMattersByCourse(int id)
    {
        return await _courseRepos.GetSubjectMattersByCourse(id);
    }

    public async Task<Course?> Update(int id,
    UpdateCourseRequestDTO updateCourseRequest)
    {
        var check = _validator.Validate(updateCourseRequest.ToCourse());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _courseRepos.UpdateAsync(id, updateCourseRequest);
    }
}
