using schoolApi.Models;

namespace schoolApi.DTOs.TeacherDtos;

public class TeacherRequestDTO
{
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public int Age { get; set; }
}
