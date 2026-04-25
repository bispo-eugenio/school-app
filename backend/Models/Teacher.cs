using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class Teacher
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    [Column(TypeName = "INT NOT NULL")]
    public int Age { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<SubjectMatter> SubjectMatters { get; set; } = [];
}
