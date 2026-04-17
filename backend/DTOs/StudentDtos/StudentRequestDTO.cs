namespace schoolApi.DTOs.StudentDtos;

public class StudentRequestDTO
{
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public int Age { get; set; }
    public int ClassroomId { get; set; }
    public int CourseId { get; set; }
}
