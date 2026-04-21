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
        };
    }

    public static CourseSubjectMatter ToCourseSubjectMatter(this CourseSubjectMatterRequestDTO courseSubjectMatterRequest)
    {
        return new CourseSubjectMatter
        {
            CourseId = courseSubjectMatterRequest.CourseId,
            SubjectMatterId = courseSubjectMatterRequest.SubjectMatterId,
        };
    }

}
