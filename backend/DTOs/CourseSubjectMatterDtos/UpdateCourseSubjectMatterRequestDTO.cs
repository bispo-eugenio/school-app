using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.CourseSubjectMatterDtos;

public class UpdateCourseSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "CourseId is required.")]
    [Display(Name = "Course Id", Description = "Please, input CourseId.")]
    [Range(1, 999999)]
    public int CourseId { get; set; }
    [Required(ErrorMessage = "SubjectMatterId is required.")]
    [Display(Name = "SubjectMatter Id", Description = "Please, input SubjectMatterId.")]
    [Range(1, 999999)]
    public int SubjectMatterId { get; set; }
}
