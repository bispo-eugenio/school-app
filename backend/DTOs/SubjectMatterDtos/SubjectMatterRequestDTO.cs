using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterRequestDTO
{
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan Hours { get; set; }
    public string Details { get; set; } = "";
}
