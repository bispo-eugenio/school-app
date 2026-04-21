namespace schoolApi.DTOs.ClassroomDtos;

public class UpdateClassroomRequestDTO
{
    public string Name { get; set; } = "";
    public int? SubjectMatterId { get; set; }
}
