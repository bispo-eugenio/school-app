using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class Course
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    [Column(TypeName = "TEXT")]
    public string? Details { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<Student> Students { get; set; } = [];
    public List<CourseSubjectMatter> CourseSubjectMatters { get; set; } = [];
}
