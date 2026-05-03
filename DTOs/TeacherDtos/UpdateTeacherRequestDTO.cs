using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.TeacherDtos;

public class UpdateTeacherRequestDTO
{
    [Required(ErrorMessage = "Teacher name is required.")]
    [Display(Name = "Teacher Name", Description = "Enter the teacher's name.")]
    [MaxLength(100, ErrorMessage = "Teacher name must not exceed 100 characters.")]
    [MinLength(3, ErrorMessage = "Teacher name must be at least 3 characters long")]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,100}$", ErrorMessage =
    "Name need to contains only letters and spaces.")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "CPF is required.")]
    [Display(Name = "Teacher CPF", Description = "Enter the teacher's CPF.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage =
    "CPF must be in the format 000.000.000-00.  ")]
    public string Cpf { get; set; } = "";
    [Required(ErrorMessage = "Age is required.")]
    [Display(Name = "Teacher Age", Description = "Enter the teacher's age.")]
    [Range(18, 140, ErrorMessage =
    "Age must be between 18 and 140.")]
    public int Age { get; set; }
}
