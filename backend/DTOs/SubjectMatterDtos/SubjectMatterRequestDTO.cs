using System.ComponentModel.DataAnnotations;
using schoolApi.Models;

namespace schoolApi.DTOs.SubjectMatterDtos;

public class SubjectMatterRequestDTO
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
    [Required(ErrorMessage = "StartedAt is required.")]
    [Display(Name = "Start time", Description = "Enter the started time's subject matter")]
    [DisplayFormat(DataFormatString = "00:00:00")]
    public TimeSpan StartedAt { get; set; }
    [Required(ErrorMessage = "EndedAt is required.")]
    [Display(Name = "End Time", Description = "Enter the ended time's subject matter")]
    [DisplayFormat(DataFormatString = "00:00:00")]
    public TimeSpan EndedAt { get; set; }
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
