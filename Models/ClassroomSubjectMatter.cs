using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schoolApi.Models;

[PrimaryKey(nameof(ClassroomId), nameof(SubjectMatterId))]
public class ClassroomSubjectMatter
{
    public int ClassroomId { get; set; }
    public int SubjectMatterId { get; set; }
    public Guid Register { get; set; } = Guid.NewGuid();
    [Column(TypeName = "ENUM('Monday', 'Tuesday', 'Wednesday'," +
    " 'Thusday', 'Friday', 'Saturday', 'Sunday', 'Undefined') DEFAULT 'Undefined'")]
    public string Day { get; set; } = "";
    [Column(TypeName = "TIME")]
    public TimeSpan StartedAt { get; set; }
    [Column(TypeName = "TIME")]
    public TimeSpan EndedAt { get; set; }
    [Column(TypeName = "TEXT")]
    public string? Details { get; set; }
    public Classroom? Classroom { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
