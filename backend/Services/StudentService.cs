using FluentValidation;
using schoolApi.DTOs.StudentDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;
    private readonly IValidator<Student> _validator;
    public StudentService(IStudentRepository studentRepo, IValidator<Student> validator)
    {
        _studentRepo = studentRepo;
        _validator = validator;
    }

    public async Task<Student> Create(Student student)
    {
        var check = _validator.Validate(student);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _studentRepo.PostAsync(student);
    }

    public async Task<Student?> Delete(int id)
    {
        return await _studentRepo.DeleteAsync(id);
    }

    public async Task<List<Student>> GetAll(StudentQueryable query)
    {
        return await _studentRepo.GetAllAsync(query);
    }

    public async Task<Student?> GetById(int id)
    {
        return await _studentRepo.GetByIdAsync(id);
    }

    public async Task<List<SubjectMatter>> GetSubjectMattersByStudent(int id)
    {
        return await _studentRepo.GetSubjectMattersByStudent(id);
    }

    public async Task<Student?> Update(int id, UpdateStudentRequestDTO updateStudentRequest)
    {
        var check = _validator
        .Validate(updateStudentRequest.ToStudent());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _studentRepo.UpdateAsync(id, updateStudentRequest);
    }
}
