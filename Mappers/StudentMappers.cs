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
            CourseId = studentModel.CourseId,
            StudentSubjectMatters = studentModel.StudentSubjectMatters.Select(ss => ss.ToDTO()).ToList(),
        };
    }

    public static Student ToStudent(this StudentRequestDTO studentRequest)
    {
        return new Student
        {
            Name = studentRequest.Name,
            Cpf = studentRequest.Cpf,
            Age = studentRequest.Age,
            CourseId = studentRequest.CourseId,
        };
    }


    public static Student ToStudent(this UpdateStudentRequestDTO updateStudentRequest)
    {
        return new Student
        {
            Name = updateStudentRequest.Name,
            Cpf = updateStudentRequest.Cpf,
            Age = updateStudentRequest.Age,
            CourseId = updateStudentRequest.CourseId,
        };
    }

    public static StudentViewDTO ToViewDTO(this Student studentModel)
    {
        return new StudentViewDTO
        {
            Id = studentModel.Id,
            Register = studentModel.Register,
            Name = studentModel.Name,
            Cpf = studentModel.Cpf,
            Age = studentModel.Age,
            CourseId = studentModel.CourseId
        };
    }
}
