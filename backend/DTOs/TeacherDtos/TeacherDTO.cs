using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Models;

namespace schoolApi.DTOs.TeacherDtos;

public class TeacherDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public int Age { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<SubjectMatterDTO> SubjectMatters { get; set; } = [];
}
