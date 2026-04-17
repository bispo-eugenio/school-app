using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class SubjectMatterMappers
{
    public static SubjectMatterDTO ToDTO(this SubjectMatter subjectMatterModel)
    {
        return new SubjectMatterDTO
        {
            Id = subjectMatterModel.Id,
            Register = subjectMatterModel.Register,
            Name = subjectMatterModel.Name,
            Day = subjectMatterModel.Day,
            Hours = subjectMatterModel.Hours,
            Details = subjectMatterModel.Details,
            CreatedOn = subjectMatterModel.CreatedOn,
            StudentSubjectMatters = subjectMatterModel.StudentSubjectMatters,
            Courses = subjectMatterModel.Courses,
            Classroom = subjectMatterModel.Classroom,
            Teacher = subjectMatterModel.Teacher
        };
    }

    public static SubjectMatter ToSubjectMatter(this SubjectMatterRequestDTO subjectMatterRequest)
    {
        return new SubjectMatter
        {
            Name = subjectMatterRequest.Name,
            Day = subjectMatterRequest.Day,
            Hours = subjectMatterRequest.Hours,
            Details = subjectMatterRequest.Details,
        };
    }
}
