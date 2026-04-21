namespace schoolApi.DTOs.StudentDtos;

public class UpdateStudentRequestDTO
{
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public int Age { get; set; }
    public int CourseId { get; set; }
}
