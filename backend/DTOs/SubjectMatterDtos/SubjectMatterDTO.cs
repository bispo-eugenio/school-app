using System.Text.Json.Serialization;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.DTOs.CourseSubjectMatterDtos;
namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan StartedAt { get; set; }
    public TimeSpan EndedAt { get; set; }
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public List<StudentSubjectMatterDTO> StudentSubjectMatters { get; set; } = [];
    [JsonIgnore]
    public List<CourseSubjectMatterDTO> CourseSubjectMatters { get; set; } = [];
    public ClassroomViewDTO? Classroom { get; set; }
    public int? TeacherId { get; set; }
}
