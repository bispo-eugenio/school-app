using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class Student
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "CPF is required.")]
    public string Cpf { get; set; } = "";
    [Required(ErrorMessage = "Age is required.")]
    [Column(TypeName = "INT(140) CHECK (Age < 24 AND Age >= 18) NOT NULL")]
    public int Age { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "ClassroomId is required.")]
    public int ClassroomId { get; set; }
    public int CourseId { get; set; }
    public List<StudentSubjectMatter> StudentSubjectMatters { get; set; } = [];
}
