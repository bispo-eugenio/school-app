using FluentValidation;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Helpers.Validators;
using schoolApi.Interfaces;
using schoolApi.Models;
using schoolApi.Mappers;

namespace schoolApi.Services;

public class ClassroomService : IClassroomService
{
    private readonly IValidator<Classroom> _validator;
    private readonly IClassroomRepository _classroomRepo;
    public ClassroomService(IClassroomRepository classroomRepo,
    IValidator<Classroom> validator)
    {
        _classroomRepo = classroomRepo;
        _validator = validator;
    }

    public async Task<Classroom?> Delete(int id)
    {
        return await _classroomRepo.DeleteAsync(id);
    }

    public async Task<List<Classroom>> GetAll(ClassroomQueryable query)
    {
        return await _classroomRepo.GetAllAsync(query);
    }

    public async Task<Classroom?> GetById(int id)
    {
        return await _classroomRepo.GetByIdAsync(id);
    }

    public async Task<Classroom> Create(Classroom classroom)
    {
        var check = _validator.Validate(classroom);
        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _classroomRepo.PostAsync(classroom);
    }

    public async Task<Classroom?> Update(int id,
    UpdateClassroomRequestDTO updateClassroomRequest)
    {
        var check = _validator.Validate(updateClassroomRequest.ToClassroom());
        if (!check.IsValid)
            throw new ValidationException(check.Errors);

        return await _classroomRepo.UpdateAsync(id, updateClassroomRequest);
    }
}
