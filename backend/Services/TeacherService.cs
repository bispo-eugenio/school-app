using FluentValidation;
using schoolApi.DTOs.TeacherDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Models;

namespace schoolApi.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepo;
    private readonly IValidator<Teacher> _validator;
    public TeacherService(ITeacherRepository teacherRepo, IValidator<Teacher> validator)
    {
        _teacherRepo = teacherRepo;
        _validator = validator;
    }

    public async Task<Teacher> Create(Teacher teacher)
    {
        var check = _validator.Validate(teacher);

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _teacherRepo.PostAsync(teacher);
    }

    public async Task<Teacher?> Delete(int id)
    {
        return await _teacherRepo.DeleteAsync(id);
    }

    public async Task<List<Teacher>> GetAll(TeacherQueryable query)
    {
        return await _teacherRepo.GetAllAsync(query);
    }

    public async Task<Teacher?> GetById(int id)
    {
        return await _teacherRepo.GetByIdAsync(id);
    }

    public async Task<Teacher?> Update(int id, UpdateTeacherRequestDTO updateTeacherRequest)
    {
        var check = _validator.Validate(updateTeacherRequest.ToTeacher());

        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _teacherRepo.UpdateAsync(id, updateTeacherRequest);
    }

}
