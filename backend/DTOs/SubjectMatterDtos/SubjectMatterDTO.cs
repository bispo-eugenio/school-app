using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.DTOs.CourseDtos;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan Hours { get; set; }
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public List<StudentSubjectMatterDTO> StudentSubjectMatters { get; set; } = [];
    public List<CourseSubjectMatterDTO> CourseSubjectMatters { get; set; } = [];
    public Classroom? Classroom { get; set; }
    public int? TeacherId { get; set; }
}
