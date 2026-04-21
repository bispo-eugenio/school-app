using Microsoft.EntityFrameworkCore;

namespace schoolApi.Models;

[PrimaryKey(nameof(CourseId), nameof(SubjectMatterId))]
public class CourseSubjectMatter
{
    public int CourseId { get; set; }
    public int SubjectMatterId { get; set; }
}
