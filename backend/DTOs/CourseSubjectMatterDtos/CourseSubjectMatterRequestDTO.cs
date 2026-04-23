using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.CourseSubjectMatterDtos;

public class CourseSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "CourseID", Description = "Select the course ID.")]
    [Range(1, 999999,
    ErrorMessage = "Course ID must be between 1 and 999999.")]
    public int CourseId { get; set; }
    [Required(ErrorMessage = "Subject Matter ID is required.")]
    [Display(Name = "SubjectMatter ID",
    Description = "Select the subject matter.")]
    [Range(1, 999999,
    ErrorMessage = "Subject Matter ID must be between 1 and 999999.")]
    public int SubjectMatterId { get; set; }
}
