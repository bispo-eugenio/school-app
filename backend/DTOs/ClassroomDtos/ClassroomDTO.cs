namespace schoolApi.DTOs.ClassroomDtos;

public class ClassroomDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public int? SubjectMatterId { get; set; }
}
