using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.StudentDtos;

public class StudentRequestDTO
{
    [Required(ErrorMessage = "Student name is required.")]
    [Display(Name = "Student Name",
    Description = "Enter the student's name.")]
    [MaxLength(100,
    ErrorMessage = "Student name must not exceed 100 characters.")]
    [MinLength(3,
    ErrorMessage = "Student name must be at least 3 characters long.")]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,100}$", ErrorMessage =
    "Student name must contain only letters and spaces.")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "CPF is required.")]
    [Display(Name = "Student CPF", Description = "Enter the Student's CPF.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage =
    "CPF must be in the format 000.000.000-00.")]
    public string Cpf { get; set; } = "";
    [Required(ErrorMessage = "Age is required.")]
    [Display(Name = "Student Age", Description = "Enter the student's age.")]
    [Range(18, 140, ErrorMessage =
    "Age must be between 18 and 140.")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "Course ID", Description = "Select the course ID.")]
    [Range(1, 999999, ErrorMessage = "CourseId must be between 1 and 999999.")]
    public int CourseId { get; set; }
}
