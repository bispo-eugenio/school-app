using FluentValidation;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class CourseSubjectMatterService : ICourseSubjectMatterService
{
    private readonly IValidator<CourseSubjectMatter> _validator;
    private readonly ICourseSubjectMatterRepository _courseSubjectMatterRepo;
    public CourseSubjectMatterService
    (ICourseSubjectMatterRepository courseSubjectMatterRepo,
    IValidator<CourseSubjectMatter> validator)
    {
        _courseSubjectMatterRepo = courseSubjectMatterRepo;
        _validator = validator;
    }

    public async Task<CourseSubjectMatter?> Delete(List<int> dualId)
    {
        return await _courseSubjectMatterRepo.DeleteAsync(dualId);
    }

    public async Task<List<CourseSubjectMatter>>
    GetAll(CourseSubjectMatterQueryable query)
    {
        return await _courseSubjectMatterRepo.GetAllAsync(query);
    }

    public async Task<CourseSubjectMatter?> GetById(List<int> dualId)
    {
        return await _courseSubjectMatterRepo.GetByIdAsync(dualId);
    }

    public async Task<CourseSubjectMatter> Create(CourseSubjectMatter courseSubjectMatterRequest)
    {
        var check = _validator.Validate(courseSubjectMatterRequest);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _courseSubjectMatterRepo.PostAsync(courseSubjectMatterRequest);
    }

    public async Task<CourseSubjectMatter?> Update(List<int> dualId, UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest)
    {
        var check = _validator
        .Validate(updateCourseSubjectMatterRequest.ToCourseSubjectMatter());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _courseSubjectMatterRepo
        .UpdateAsync(dualId, updateCourseSubjectMatterRequest);
    }
}
