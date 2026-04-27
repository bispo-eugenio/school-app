using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class ClassroomSubjectMatterMappers
{

    public static ClassroomSubjectMatterDTO
    ToDTO(this ClassroomSubjectMatter classroomSubjectMatterModel)
    {
        return new ClassroomSubjectMatterDTO
        {
            ClassroomId = classroomSubjectMatterModel.ClassroomId,
            SubjectMatterId = classroomSubjectMatterModel.SubjectMatterId,
            Register = classroomSubjectMatterModel.Register,
            Day = classroomSubjectMatterModel.Day,
            StartedAt = classroomSubjectMatterModel.StartedAt,
            EndedAt = classroomSubjectMatterModel.EndedAt,
            Classroom = classroomSubjectMatterModel.Classroom?.ToViewDTO(),
            Details = classroomSubjectMatterModel.Details,
            CreatedOn = classroomSubjectMatterModel.CreatedOn
        };
    }

    public static ClassroomSubjectMatter
    ToClassroomSubjectMatter(
    this ClassroomSubjectMatterRequestDTO classroomSubjectMatterRequest)
    {
        return new ClassroomSubjectMatter
        {
            ClassroomId = classroomSubjectMatterRequest.ClassroomId,
            SubjectMatterId = classroomSubjectMatterRequest.SubjectMatterId,
            Day = classroomSubjectMatterRequest.Day,
            StartedAt = classroomSubjectMatterRequest.StartedAt,
            EndedAt = classroomSubjectMatterRequest.EndedAt,
            Details = classroomSubjectMatterRequest.Details,
        };
    }

    public static ClassroomSubjectMatterViewDTO
    ToViewDTO(this ClassroomSubjectMatter classroomSubjectMatterModel)
    {
        return new ClassroomSubjectMatterViewDTO
        {
            ClassroomId = classroomSubjectMatterModel.ClassroomId,
            SubjectMatterId = classroomSubjectMatterModel.SubjectMatterId,
            Register = classroomSubjectMatterModel.Register,
            Day = classroomSubjectMatterModel.Day,
            StartedAt = classroomSubjectMatterModel.StartedAt,
            EndedAt = classroomSubjectMatterModel.EndedAt,
            Classroom = classroomSubjectMatterModel.Classroom?.ToViewDTO(),
            Details = classroomSubjectMatterModel.Details,
        };
    }

}
