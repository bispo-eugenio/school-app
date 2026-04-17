using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schoolApi.Models;

public class StudentSubjectMatter
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public int StudentId { get; set; }
    public int SubjectMatterId { get; set; }
    public Student? Student { get; set; }
    public SubjectMatter? SubjectMatter { get; set; }
    [Column(TypeName = "DECIMAL(4, 2) CHECK (RecordGradeOne <= 10) DEFAULT 0")]
    public decimal RecordGradeOne { get; set; }
    [Column(TypeName = "DECIMAL(4, 2) CHECK (RecordGradeTwo <= 10) DEFAULT 0")]
    public decimal RecordGradeTwo { get; set; }
    [Column(TypeName = "DECIMAL(4, 2) CHECK (RecordGradeTotal <= 10) DEFAULT 0")]
    public decimal RecordGradeTotal { get; set; }
}
