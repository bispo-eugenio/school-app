using FluentValidation;
using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class ClassroomSubjectMatterService : IClassroomSubjectMatterService
{
    private readonly IValidator<ClassroomSubjectMatter> _validator;
    private readonly IClassroomSubjectMatterRepository _classroomSubjectMatterRepos;
    public ClassroomSubjectMatterService(
    IClassroomSubjectMatterRepository classroomSubjectMatterRepo,
    IValidator<ClassroomSubjectMatter> validator)
    {
        _classroomSubjectMatterRepos = classroomSubjectMatterRepo;
        _validator = validator;
    }

    public async Task<ClassroomSubjectMatter> Create(
    ClassroomSubjectMatter classroomSubjectMatter)
    {
        var check = _validator.Validate(classroomSubjectMatter);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _classroomSubjectMatterRepos
        .PostAsync(classroomSubjectMatter);
    }

    public async Task<ClassroomSubjectMatter?> Delete(List<int> dualId)
    {
        return await _classroomSubjectMatterRepos.DeleteAsync(dualId);
    }

    public async Task<List<ClassroomSubjectMatter>> GetAll(
    ClassroomSubjectMatterQueryable query)
    {
        return await _classroomSubjectMatterRepos.GetAllAsync(query);
    }

    public async Task<ClassroomSubjectMatter?> GetById(List<int> dualId)
    {
        return await _classroomSubjectMatterRepos.GetByIdAsync(dualId);
    }

    public async Task<ClassroomSubjectMatter?> Update(List<int> dualId,
    UpdateClassroomSubjectMatterRequestDTO updateClassroomSubjectMatterRequest)
    {
        var check = _validator.Validate(updateClassroomSubjectMatterRequest
        .ToClassroomSubjectMatter());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _classroomSubjectMatterRepos
        .UpdateAsync(dualId,
        updateClassroomSubjectMatterRequest);
    }
}
