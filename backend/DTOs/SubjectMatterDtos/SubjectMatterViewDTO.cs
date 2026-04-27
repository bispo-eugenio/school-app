using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.DTOs.CourseDtos;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterViewDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string? Details { get; set; }
    public List<ClassroomSubjectMatterViewDTO> ClassroomSubjectMatters { get; set; } = [];
    public int? TeacherId { get; set; }
}
