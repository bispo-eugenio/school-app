using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.ClassroomSubjectMatterDtos;

public class UpdateClassroomSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "ClassroomId is required")]
    [Display(Name = "Classroom Id",
    Description = "Enter the classroom Id's ClassroomSubjectMatter")]
    [Range(1, 999999,
    ErrorMessage = "ClassroomId must be between 1 and 999999.")]
    public int ClassroomId { get; set; }
    [Required(ErrorMessage = "SubjectMatterId is required")]
    [Display(Name = "Subject Matter Id",
    Description = "Enter the subject matter Id's ClassroomSubjectMatter")]
    [Range(1, 999999,
    ErrorMessage = "SubjectMatterId must be between 1 and 999999.")]
    public int SubjectMatterId { get; set; }
    [Required(ErrorMessage = "Day is required.")]
    [Display(Name = "Day",
    Description = "Enter the day of the classroom subject matter")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{6,9}$", ErrorMessage =
    "Day must contain only words (Monday, Friday, etc")]
    public string Day { get; set; } = "";
    [Required(ErrorMessage = "StartedAt is required.")]
    [Display(Name = "Start time",
    Description = "Enter the started time's classroom subject matter")]
    [DisplayFormat(DataFormatString = "00:00:00")]
    public TimeSpan StartedAt { get; set; }
    [Required(ErrorMessage = "EndedAt is required.")]
    [Display(Name = "End Time",
    Description = "Enter the ended time's classroom subject matter")]
    [DisplayFormat(DataFormatString = "00:00:00")]
    public TimeSpan EndedAt { get; set; }
    [Display(Name = "Classroom Subject matter Details",
    Description =
    "Provide  a detailed description of the Classroom Subject Matter.")]
    [MaxLength(1000,
    ErrorMessage =
    "Classroom Subject matter detail must not exceed 1000 characters.")]
    [MinLength(10,
    ErrorMessage =
    "Classroom Subject matter detail must be at least 10 character long.")]
    public string? Details { get; set; }
}
