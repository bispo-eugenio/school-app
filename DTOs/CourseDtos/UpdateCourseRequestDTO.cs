using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.CourseDtos;

public class UpdateCourseRequestDTO
{
    [Required(ErrorMessage = "Course name is required.")]
    [Display(Name = "Course Name", Description = "Enter the name of the course.")]
    [MaxLength(100,
    ErrorMessage = "Course name must not exceed 100 characters.")]
    [MinLength(4,
    ErrorMessage = "Course name must be at least 4 character long.")]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{4,100}$", ErrorMessage =
    "Course name must contain only letters e spaces.")]
    public string Name { get; set; } = "";
    [Display(Name = "Course Details",
    Description = "Provide a detailed description of the course.")]
    [MaxLength(1000, ErrorMessage = "Course detail must not exceed 1000 characters.")]
    [MinLength(10, ErrorMessage = "Course detail must be at least 10 character long.")]
    public string? Details { get; set; }
}
