namespace schoolApi.DTOs.SubjectMatterDtos;

public class UpdateSubjectMatterRequestDTO
{
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan Hours { get; set; }
    public string Details { get; set; } = "";
    public int? TeacherId { get; set; }
}
