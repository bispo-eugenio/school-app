using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.ClassroomSubjectMatterDtos;

public class ClassroomSubjectMatterDTO
{
    public int ClassroomId { get; set; }
    public int SubjectMatterId { get; set; }
    public Guid Register { get; set; }
    public string Day { get; set; } = "";
    public TimeSpan StartedAt { get; set; }
    public TimeSpan EndedAt { get; set; }
    public string? Details { get; set; }
    public ClassroomViewDTO? Classroom { get; set; }
    public DateTime CreatedOn { get; set; }
}
