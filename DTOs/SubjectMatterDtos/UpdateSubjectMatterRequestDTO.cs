using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class UpdateSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "Subject matter name is required.")]
    [Display(Name = "Subject Matter Name",
    Description = "Enter the subject matter name.")]
    [MaxLength(100,
    ErrorMessage = "Subject matter must not exceed 100 characters.")]
    [MinLength(3,
    ErrorMessage = "Subject matter must be at least 3 characters long.")]
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,100}$", ErrorMessage =
    "Name need to contains only letters and spaces.")]
    public string Name { get; set; } = "";
    [Display(Name = "Subject matter Details",
    Description = "Provide  a detailed description of the Subject matter.")]
    [MaxLength(1000, ErrorMessage = "Subject matter detail must not exceed 1000 characters.")]
    [MinLength(10, ErrorMessage = "Subject matter detail must be at least 10 character long.")]
    public string Details { get; set; } = "";
    [Required(ErrorMessage = "Teacher ID is required.")]
    [Display(Name = "Teacher ID",
    Description = "Select the teacher ID.")]
    [Range(1, 999999, ErrorMessage = "Teacher ID must be between 1 and 999999.")]
    public int? TeacherId { get; set; }
}
