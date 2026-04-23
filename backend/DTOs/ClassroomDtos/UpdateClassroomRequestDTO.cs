using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.ClassroomDtos;

public class UpdateClassroomRequestDTO
{
    [Required(ErrorMessage = "Classroom name is required.")]
    [Display(Name = "Classroom Name", Description = "Enter the classroom name.")]
    [MaxLength(100,
    ErrorMessage = "Classroom name must not exceed 100 characters.")]
    [MinLength(10,
    ErrorMessage = "Classroom name must be at least 10 characters long.")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{10,100}$",
    ErrorMessage =
    "Classroom name must contain only letter and spaces")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Subject Matter Id is required.")]
    [Display(Name = "SubjectMatter Id",
    Description = "Select the subject matter Id.")]
    [Range(1, 999999,
    ErrorMessage = "Subject Matter Id must be between 1 and 999999.")]
    public int? SubjectMatterId { get; set; } = null;
}
