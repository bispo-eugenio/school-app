using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schoolApi.Models;

[PrimaryKey(nameof(CourseId), nameof(SubjectMatterId))]
public class CourseSubjectMatter
{
    public int CourseId { get; set; }
    public int SubjectMatterId { get; set; }
    [Column(TypeName = "TINYINT(1) NOT NULL DEFAULT 0")]
    public int IsActived { get; set; } = 0;
    public int WorkloadHours { get; set; }
    public int Semester { get; set; }
    [Column(TypeName = "TINYINT(1) NOT NULL DEFAULT 0")]
    public int IsMandatory { get; set; } = 0;
    [Column(TypeName = "TEXT")]
    public string? Details { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
