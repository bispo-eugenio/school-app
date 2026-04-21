using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.DTOs.StudentDtos;
using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.CourseDtos;

public class CourseDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public List<StudentDTO> Students { get; set; } = [];
    public List<CourseSubjectMatterDTO> CourseSubjectMatters { get; set; } = [];
}
