using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Helpers;
using schoolApi.Models;

namespace schoolApi.Mappers;

public static class StudentSubjectMatterMappers
{
    public static StudentSubjectMatterDTO
    ToDTO(this StudentSubjectMatter studentSubjectMatterModel)
    {
        return new StudentSubjectMatterDTO
        {
            Register = studentSubjectMatterModel.Register,
            StudentId = studentSubjectMatterModel.StudentId,
            SubjectMatterId = studentSubjectMatterModel.SubjectMatterId,
            FirstGrade = studentSubjectMatterModel.FirstGrade,
            SecondGrade = studentSubjectMatterModel.SecondGrade,
            GradeTotal = studentSubjectMatterModel.GradeTotal
        };
    }

    public static StudentSubjectMatter
    ToStudentSubjectMatter(this StudentSubjectMatterRequestDTO
    studentSubjectMatterRequest)
    {
        return new StudentSubjectMatter
        {
            StudentId = studentSubjectMatterRequest.StudentId,
            SubjectMatterId = studentSubjectMatterRequest.SubjectMatterId,
            FirstGrade = studentSubjectMatterRequest.FirstGrade,
            SecondGrade = studentSubjectMatterRequest.SecondGrade,
            GradeTotal = MathExtensions.Average(
                [studentSubjectMatterRequest.FirstGrade,
                studentSubjectMatterRequest.SecondGrade])
        };
    }


    public static StudentSubjectMatter
    ToStudentSubjectMatter(this UpdateStudentSubjectMatterRequestDTO
    updateStudentSubjectMatterRequest)
    {
        return new StudentSubjectMatter
        {
            StudentId = updateStudentSubjectMatterRequest.StudentId,
            SubjectMatterId = updateStudentSubjectMatterRequest.SubjectMatterId,
            FirstGrade = updateStudentSubjectMatterRequest.FirstGrade,
            SecondGrade = updateStudentSubjectMatterRequest.SecondGrade,
            GradeTotal = MathExtensions.Average(
                [updateStudentSubjectMatterRequest.FirstGrade,
                updateStudentSubjectMatterRequest.SecondGrade])
        };
    }
}
