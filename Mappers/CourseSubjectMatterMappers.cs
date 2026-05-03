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
            IsMandatory = courseSubjectMatter.IsMandatory,
            Details = courseSubjectMatter.Details
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
            IsMandatory = courseSubjectMatterRequest.IsMandatory,
            Details = courseSubjectMatterRequest.Details
        };
    }

    public static CourseSubjectMatter ToCourseSubjectMatter
    (this UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest)
    {
        return new CourseSubjectMatter
        {
            CourseId = updateCourseSubjectMatterRequest.CourseId,
            SubjectMatterId = updateCourseSubjectMatterRequest.SubjectMatterId,
            IsActived = updateCourseSubjectMatterRequest.IsActived,
            WorkloadHours = updateCourseSubjectMatterRequest.WorkloadHours,
            Semester = updateCourseSubjectMatterRequest.Semester,
            IsMandatory = updateCourseSubjectMatterRequest.IsMandatory,
            Details = updateCourseSubjectMatterRequest.Details
        };
    }

}
