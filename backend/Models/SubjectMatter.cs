using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class SubjectMatter
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    [Column(TypeName = "ENUM('Monday', 'Tuesday', ' Wednesday'," +
    " 'Thusday', 'Friday', 'Saturday', 'Sunday') DEFAULT 'Monday'")]
    public string Day { get; set; } = "";
    [Column(TypeName = "DATETIME")]
    public DateTime Hours { get; set; }
    [Column(TypeName = "TEXT")]
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<StudentSubjectMatter> StudentSubjectMatters { get; set; } = [];
    public List<Course> Courses { get; set; } = [];
    public Classroom? Classroom { get; set; }
    public Teacher? Teacher { get; set; }
}
