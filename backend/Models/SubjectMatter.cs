using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class SubjectMatter
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    [Column(TypeName = "ENUM('Monday', 'Tuesday', ' Wednesday'," +
    " 'Thusday', 'Friday', 'Saturday', 'Sunday', 'Undefined') DEFAULT 'Undefined'")]
    public string Day { get; set; } = "";
    [Column(TypeName = "TIME")]
    public TimeSpan StartedAt { get; set; }
    [Column(TypeName = "TIME")]
    public TimeSpan EndedAt { get; set; }
    [Column(TypeName = "TEXT")]
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<StudentSubjectMatter> StudentSubjectMatters { get; set; } = [];
    public List<CourseSubjectMatter> CourseSubjectMatters { get; set; } = [];
    public Classroom? Classroom { get; set; } = null;
    public int? TeacherId { get; set; }
}
