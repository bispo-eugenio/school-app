using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schoolApi.Models;

[PrimaryKey(nameof(StudentId), nameof(SubjectMatterId))]
public class StudentSubjectMatter
{
    public int StudentId { get; set; }
    public int SubjectMatterId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    [Column(TypeName = "DECIMAL(4, 2) CHECK (FirstGrade <= 10) DEFAULT 0")]
    public decimal FirstGrade { get; set; }
    [Column(TypeName = "DECIMAL(4, 2) CHECK (SecondGrade <= 10) DEFAULT 0")]
    public decimal SecondGrade { get; set; }
    [Column(TypeName = "DECIMAL(4, 2) CHECK (GradeTotal <= 10) DEFAULT 0")]
    public decimal GradeTotal { get; set; }
}
