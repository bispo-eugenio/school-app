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
            ClassroomSubjectMatters = classroomModel.ClassroomSubjectMatters
            .Select(csm => csm.ToViewDTO()).ToList()
        };
    }

    public static Classroom ToClassroom(this ClassroomRequestDTO classroomRequest)
    {
        return new Classroom
        {
            Name = classroomRequest.Name
        };
    }

    public static Classroom ToClassroom(this UpdateClassroomRequestDTO updateClassroomRequest)
    {
        return new Classroom
        {
            Name = updateClassroomRequest.Name
        };
    }

    public static ClassroomViewDTO ToViewDTO(this Classroom classroomModel)
    {
        return new ClassroomViewDTO
        {
            Id = classroomModel.Id,
            Register = classroomModel.Register,
            Name = classroomModel.Name,
        };
    }

}
