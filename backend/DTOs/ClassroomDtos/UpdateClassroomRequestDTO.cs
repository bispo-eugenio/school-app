using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.ClassroomDtos;

public class UpdateClassroomRequestDTO
{
    [Required(ErrorMessage = "Classroom name is required.")]
    [Display(Name = "Classroom Name", Description = "Enter the classroom name.")]
    [MaxLength(10,
    ErrorMessage = "Classroom name must not exceed 10 characters.")]
    [MinLength(4,
    ErrorMessage = "Classroom name must be at least 4 characters long.")]
    [RegularExpression(@"^[A-Za-z]{1,5}-?[0-9]{1,4}[A-Za-z]?$",
    ErrorMessage =
    "Classroom name must contain only letter or numerics (LAB1, INFO-3, CLASS-43A, etc")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Subject Matter Id is required.")]
    [Display(Name = "SubjectMatter Id",
    Description = "Select the subject matter Id.")]
    [Range(1, 999999,
    ErrorMessage = "Subject Matter Id must be between 1 and 999999.")]
    public int? SubjectMatterId { get; set; } = null;
}
