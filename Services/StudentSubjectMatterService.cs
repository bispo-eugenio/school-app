using FluentValidation;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class StudentSubjectMatterService : IStudentSubjectMatterService
{
    private readonly IStudentSubjectMatterRepository _studentSubjectMatterRepo;
    private readonly IValidator<StudentSubjectMatter> _validator;
    public StudentSubjectMatterService
    (IStudentSubjectMatterRepository studentSubjectMatterRepo,
    IValidator<StudentSubjectMatter> validator)
    {
        _studentSubjectMatterRepo = studentSubjectMatterRepo;
        _validator = validator;
    }

    public async Task<StudentSubjectMatter> Create
    (StudentSubjectMatter studentSubjectMatter)
    {
        var check = _validator.Validate(studentSubjectMatter);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _studentSubjectMatterRepo.PostAsync(studentSubjectMatter);
    }

    public async Task<StudentSubjectMatter?> Delete(List<int> dualId)
    {
        return await _studentSubjectMatterRepo.DeleteAsync(dualId);
    }

    public async Task<List<StudentSubjectMatter>> GetAll
    (StudentSubjectMatterQueryable query)
    {
        return await _studentSubjectMatterRepo.GetAllAsync(query);
    }

    public async Task<StudentSubjectMatter?> GetById(List<int> dualId)
    {
        return await _studentSubjectMatterRepo.GetByIdAsync(dualId);
    }

    public async Task<StudentSubjectMatter?> Update
    (List<int> dualId,
    UpdateStudentSubjectMatterRequestDTO updateStudentSubjectMatterRequest)
    {
        var check = _validator
        .Validate(updateStudentSubjectMatterRequest.ToStudentSubjectMatter());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _studentSubjectMatterRepo
        .UpdateAsync(dualId, updateStudentSubjectMatterRequest);
    }

}
