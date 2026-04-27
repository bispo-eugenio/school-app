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
            Details = subjectMatterModel.Details,
            CreatedOn = subjectMatterModel.CreatedOn,
            StudentSubjectMatters = subjectMatterModel.StudentSubjectMatters
            .Select(ss => ss.ToDTO()).ToList(),
            CourseSubjectMatters = subjectMatterModel.CourseSubjectMatters
            .Select(csm => csm.ToDTO()).ToList(),
            ClassroomSubjectMatters = subjectMatterModel.ClassroomSubjectMatters
            .Select(csm => csm.ToViewDTO()).ToList(),
            TeacherId = subjectMatterModel.TeacherId
        };
    }

    public static SubjectMatter ToSubjectMatter(this SubjectMatterRequestDTO subjectMatterRequest)
    {
        return new SubjectMatter
        {
            Name = subjectMatterRequest.Name,
            Details = subjectMatterRequest.Details,
            TeacherId = subjectMatterRequest.TeacherId
        };
    }

    public static SubjectMatterViewDTO ToViewDTO(this SubjectMatter subjectMatterModel)
    {
        return new SubjectMatterViewDTO
        {
            Id = subjectMatterModel.Id,
            Register = subjectMatterModel.Register,
            Name = subjectMatterModel.Name,
            Details = subjectMatterModel.Details,
            ClassroomSubjectMatters = subjectMatterModel.ClassroomSubjectMatters
            .Select(csm => csm.ToViewDTO()).ToList(),
            TeacherId = subjectMatterModel.TeacherId
        };
    }

}
