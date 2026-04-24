using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.DTOs.CourseDtos;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterViewDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan StartedAt { get; set; }
    public TimeSpan EndedAt { get; set; }
    public string Details { get; set; } = "";
    public ClassroomViewDTO? Classroom { get; set; }
    public int? TeacherId { get; set; }
}
