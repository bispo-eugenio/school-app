using schoolApi.DTOs.CourseDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class CourseMappers
{
    public static CourseDTO ToDTO(this Course courseModel)
    {
        return new CourseDTO
        {
            Id = courseModel.Id,
            Register = courseModel.Register,
            Name = courseModel.Name,
            Details = courseModel.Details,
            CreatedOn = courseModel.CreatedOn,
            Students = courseModel.Students,
            SubjectMatters = courseModel.SubjectMatters
        };
    }

    public static Course ToCourse(this CourseRequestDTO courseRequest)
    {
        return new Course
        {
            Name = courseRequest.Name,
            Details = courseRequest.Details,
        };
    }

}
