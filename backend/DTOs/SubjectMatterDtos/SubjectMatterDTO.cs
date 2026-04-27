using System.Text.Json.Serialization;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.DTOs.CourseSubjectMatterDtos;
namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string? Details { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<StudentSubjectMatterDTO> StudentSubjectMatters { get; set; } = [];
    public List<CourseSubjectMatterDTO> CourseSubjectMatters { get; set; } = [];
    public List<ClassroomSubjectMatterViewDTO> ClassroomSubjectMatters { get; set; } = [];
    public int? TeacherId { get; set; }
}
