using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.CourseSubjectMatterDtos;

public class CourseSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "CourseID", Description = "Select the course ID.")]
    [Range(1, 999999,
    ErrorMessage = "Course ID must be between 1 and 999999.")]
    public int CourseId { get; set; }
    [Required(ErrorMessage = "Subject Matter ID is required.")]
    [Display(Name = "SubjectMatter ID",
    Description = "Select the subject matter.")]
    [Range(1, 999999,
    ErrorMessage = "Subject Matter ID must be between 1 and 999999.")]
    public int SubjectMatterId { get; set; }
    [Required(ErrorMessage = "IsActived is required")]
    [Display(Name = "Is Actived",
    Description = "Enter the IsActived's CourseSubjectMatter.")]
    [Range(0, 1, ErrorMessage = "IsActived must be between 0 and 1.")]
    public int IsActived { get; set; }
    [Required(ErrorMessage = "WordloadHours is required.")]
    [Display(Name = "Workload Hours",
    Description = "Enter the WorkloadHours's CourseSubjectMatter.")]
    [Range(1, 100, ErrorMessage = "WorkloadHours must be between 1 and 100.")]
    public int WorkloadHours { get; set; }
    [Required(ErrorMessage = "Semester is required.")]
    [Display(Name = "Semester",
    Description = "Enter the Semester's CourseSubjectMatter.")]
    [Range(1, 100, ErrorMessage = "Semester must be between 1 and 100.")]
    public int Semester { get; set; }
    [Required(ErrorMessage = "IsMandatory is required.")]
    [Display(Name = "Is Mandatory",
    Description = "Enter the IsMandatory's CourseSubjectMatter.")]
    [Range(0, 1, ErrorMessage = "IsMandatory must be between 0 and 1.")]
    public int IsMandatory { get; set; }
    [Display(Name = "Course Subject Matter Details",
    Description = "Provide a detailed description of the course subject matter.")]
    [MaxLength(1000,
    ErrorMessage = "Course subject matter detail" +
    " must not exceed 1000 characters.")]
    [MinLength(10,
    ErrorMessage = "Course subject matter detail" +
    " must be at least 10 character long.")]
    public string? Details { get; set; }
}
