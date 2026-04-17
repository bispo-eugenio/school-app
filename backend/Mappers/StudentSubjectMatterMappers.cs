using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class StudentSubjectMatterMappers
{
    public static StudentSubjectMatterDTO ToDTO(this StudentSubjectMatter studentSubjectMatterModel)
    {
        return new StudentSubjectMatterDTO
        {
            Id = studentSubjectMatterModel.Id,
            Register = studentSubjectMatterModel.Register,
            StudentId = studentSubjectMatterModel.StudentId,
            SubjectMatterId = studentSubjectMatterModel.SubjectMatterId,
            RecordGradeOne = studentSubjectMatterModel.RecordGradeOne,
            RecordGradeTwo = studentSubjectMatterModel.RecordGradeTwo,
            RecordGradeTotal = studentSubjectMatterModel.RecordGradeTotal
        };
    }

    public static StudentSubjectMatter ToStudentSubjectMatter(this StudentSubjectMatterRequestDTO studentSubjectMatterRequest)
    {
        return new StudentSubjectMatter
        {
            StudentId = studentSubjectMatterRequest.StudentId,
            SubjectMatterId = studentSubjectMatterRequest.SubjectMatterId,
            RecordGradeOne = studentSubjectMatterRequest.RecordGradeOne,
            RecordGradeTwo = studentSubjectMatterRequest.RecordGradeTwo,
            RecordGradeTotal = studentSubjectMatterRequest.RecordGradeTotal
        };
    }
}
