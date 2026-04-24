using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class Student
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    [Column(TypeName = "INT(140) NOT NULL")]
    public int Age { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int CourseId { get; set; }
    public List<StudentSubjectMatter> StudentSubjectMatters { get; set; } = [];
}
