using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class CourseSubjectMatterMappers
{
    public static CourseSubjectMatterDTO ToDTO(this CourseSubjectMatter courseSubjectMatter)
    {
        return new CourseSubjectMatterDTO
        {
            CourseId = courseSubjectMatter.CourseId,
            SubjectMatterId = courseSubjectMatter.SubjectMatterId,
            IsActived = courseSubjectMatter.IsActived,
            WorkloadHours = courseSubjectMatter.WorkloadHours,
            Semester = courseSubjectMatter.Semester,
            IsMandatory = courseSubjectMatter.IsMandatory
        };
    }

    public static CourseSubjectMatter ToCourseSubjectMatter(this CourseSubjectMatterRequestDTO courseSubjectMatterRequest)
    {
        return new CourseSubjectMatter
        {
            CourseId = courseSubjectMatterRequest.CourseId,
            SubjectMatterId = courseSubjectMatterRequest.SubjectMatterId,
            IsActived = courseSubjectMatterRequest.IsActived,
            WorkloadHours = courseSubjectMatterRequest.WorkloadHours,
            Semester = courseSubjectMatterRequest.Semester,
            IsMandatory = courseSubjectMatterRequest.IsMandatory
        };
    }

}
