using schoolApi.Dtos.StudentSubjectMatterDtos;

namespace schoolApi.DTOs.StudentDtos;

public class StudentViewDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public int Age { get; set; }
    public int CourseId { get; set; }
}
