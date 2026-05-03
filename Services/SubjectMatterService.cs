using FluentValidation;
using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class SubjectMatterService : ISubjectMatterService
{
    private readonly ISubjectMatterRepository _subjectMatterRepo;
    private readonly IValidator<SubjectMatter> _validator;
    public SubjectMatterService(ISubjectMatterRepository subjectMatterRepo,
    IValidator<SubjectMatter> validator)
    {
        _subjectMatterRepo = subjectMatterRepo;
        _validator = validator;
    }

    public async Task<SubjectMatter> Create(SubjectMatter subjectMatter)
    {
        var check = _validator.Validate(subjectMatter);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _subjectMatterRepo.PostAsync(subjectMatter);
    }

    public async Task<SubjectMatter?> Delete(int id)
    {
        return await _subjectMatterRepo.DeleteAsync(id);
    }

    public async Task<List<SubjectMatter>> GetAll(SubjectMatterQueryable query)
    {
        return await _subjectMatterRepo.GetAllAsync(query);
    }

    public async Task<SubjectMatter?> GetById(int id)
    {
        return await _subjectMatterRepo.GetByIdAsync(id);
    }

    public async Task<List<Course>> GetCoursesBySubjectMatter(int id)
    {
        return await _subjectMatterRepo.GetCoursesBySubjectMatter(id);
    }

    public async Task<List<Student>> GetStudentsBySubjectMatter(int id)
    {
        return await _subjectMatterRepo.GetStudentsBySubjectMatter(id);
    }

    public async Task<SubjectMatter?> Update
    (int id, UpdateSubjectMatterRequestDTO updateSubjectMatterRequest)
    {
        var check = _validator
        .Validate(updateSubjectMatterRequest.ToSubjectMatter());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _subjectMatterRepo
        .UpdateAsync(id, updateSubjectMatterRequest);
    }

}
