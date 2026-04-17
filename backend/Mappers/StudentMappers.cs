using schoolApi.DTOs.StudentDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class StudentMappers
{
    public static StudentDTO ToDTO(this Student studentModel)
    {
        return new StudentDTO
        {
            Id = studentModel.Id,
            Register = studentModel.Register,
            Name = studentModel.Name,
            Cpf = studentModel.Cpf,
            Age = studentModel.Age,
            CreatedOn = studentModel.CreatedOn,
            ClassroomId = studentModel.ClassroomId,
            CourseId = studentModel.CourseId,
            StudentSubjectMatters = studentModel.StudentSubjectMatters
        };
    }

    public static Student ToStudent(this StudentRequestDTO studentRequest)
    {
        return new Student
        {
            Name = studentRequest.Name,
            Cpf = studentRequest.Cpf,
            Age = studentRequest.Age,
            ClassroomId = studentRequest.ClassroomId,
            CourseId = studentRequest.CourseId,
        };
    }
}
