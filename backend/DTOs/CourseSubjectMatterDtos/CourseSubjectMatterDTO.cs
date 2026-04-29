namespace schoolApi.DTOs.CourseSubjectMatterDtos;

public class CourseSubjectMatterDTO
{
    public int CourseId { get; set; }
    public int SubjectMatterId { get; set; }
    public int IsActived { get; set; }
    public int WorkloadHours { get; set; }
    public int Semester { get; set; }
    public int IsMandatory { get; set; }
    public string? Details { get; set; }
}
