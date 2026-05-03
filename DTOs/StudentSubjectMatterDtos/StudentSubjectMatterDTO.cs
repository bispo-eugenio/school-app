using schoolApi.Models;

namespace schoolApi.Dtos.StudentSubjectMatterDtos;

public class StudentSubjectMatterDTO
{
    public Guid Register { get; set; }
    public int StudentId { get; set; }
    public int SubjectMatterId { get; set; }
    public decimal FirstGrade { get; set; }
    public decimal SecondGrade { get; set; }
    public decimal GradeTotal { get; set; }
}
