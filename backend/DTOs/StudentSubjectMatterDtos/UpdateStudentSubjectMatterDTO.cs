namespace schoolApi.Dtos.StudentSubjectMatterDtos;

public class UpdateStudentSubjectMatterRequestDTO
{
    public int StudentId { get; set; }
    public int SubjectMatterId { get; set; }
    public decimal RecordGradeOne { get; set; }
    public decimal RecordGradeTwo { get; set; }
}
