using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterDTO
{
    public int Id { get; set; }
    public Guid Register { get; set; }
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public DateTime Hours { get; set; }
    public string Details { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public List<StudentSubjectMatter> StudentSubjectMatters { get; set; } = [];
    public List<Course> Courses { get; set; } = [];
    public Classroom? Classroom { get; set; }
    public Teacher? Teacher { get; set; }
}
