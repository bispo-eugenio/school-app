using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class UpdateSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "Subject matter name is required.")]
    [Display(Name = "Subject Matter Name",
    Description = "Enter the subject matter name.")]
    [MaxLength(100,
    ErrorMessage = "Subject matter must not exceed 100 characters.")]
    [MinLength(10,
    ErrorMessage = "Subject matter must be at least 10 characters long.")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage =
    "Name need to contains only letters and spaces.")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Day is required.")]
    [Display(Name = "Day", Description = "Enter the day of the subject matter")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{6,9}$", ErrorMessage =
    "Day must contain only words (Monday, Friday, etc")]
    public string Day { get; set; } = "";
    [Required(ErrorMessage = "Time is required.")]
    [Display(Name = "Time", Description = "Enter the time's subject matter")]
    [DisplayFormat(DataFormatString = "00:00:00")]
    public TimeSpan Hours { get; set; }
    [Required(ErrorMessage = "Subject matter details is required.")]
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
