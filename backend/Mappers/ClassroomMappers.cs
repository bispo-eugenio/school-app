using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class ClassroomMappers
{
    public static ClassroomDTO ToDTO(this Classroom classroomModel)
    {
        return new ClassroomDTO
        {
            Id = classroomModel.Id,
            Register = classroomModel.Register,
            Name = classroomModel.Name,
            CreatedOn = classroomModel.CreatedOn,
            SubjectMatterId = classroomModel.SubjectMatterId
        };
    }

    public static Classroom ToClassroom(this ClassroomRequestDTO classroomRequest)
    {
        return new Classroom
        {
            Name = classroomRequest.Name,
            SubjectMatterId = classroomRequest.SubjectMatterId
        };
    }
}
