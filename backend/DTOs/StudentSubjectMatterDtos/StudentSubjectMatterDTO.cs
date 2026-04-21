using schoolApi.Models;

namespace schoolApi.Dtos.StudentSubjectMatterDtos;

public class StudentSubjectMatterDTO
{
    public Guid Register { get; set; }
    public int StudentId { get; set; }
    public int SubjectMatterId { get; set; }
    public decimal RecordGradeOne { get; set; }
    public decimal RecordGradeTwo { get; set; }
    public decimal RecordGradeTotal { get; set; }
}
