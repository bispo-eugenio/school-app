using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolApi.Models;

public class Classroom
{
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Register { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? SubjectMatterId { get; set; } = null;
}
