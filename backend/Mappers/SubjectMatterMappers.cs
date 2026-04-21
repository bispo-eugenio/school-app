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
            StudentSubjectMatters = subjectMatterModel.StudentSubjectMatters.Select(ss => ss.ToDTO()).ToList(),
            CourseSubjectMatters = subjectMatterModel.CourseSubjectMatters.Select(csm => csm.ToDTO()).ToList(),
            Classroom = subjectMatterModel.Classroom,
            TeacherId = subjectMatterModel.TeacherId
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
            TeacherId = subjectMatterRequest.TeacherId
        };
    }
}
