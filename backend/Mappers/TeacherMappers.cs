using schoolApi.DTOs.TeacherDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class TeacherMappers
{
    public static TeacherDTO ToDTO(this Teacher teacherModel)
    {
        return new TeacherDTO
        {
            Id = teacherModel.Id,
            Register = teacherModel.Register,
            Name = teacherModel.Name,
            Cpf = teacherModel.Cpf,
            Age = teacherModel.Age,
            CreatedOn = teacherModel.CreatedOn,
            SubjectMatters = teacherModel.SubjectMatters,
        };
    }

    public static Teacher ToTeacher(this TeacherRequestDTO teacherRequest)
    {
        return new Teacher
        {
            Name = teacherRequest.Name,
            Cpf = teacherRequest.Cpf,
            Age = teacherRequest.Age,
        };
    }
}
