using System.ComponentModel.DataAnnotations;

namespace schoolApi.Dtos.StudentSubjectMatterDtos;

public class UpdateStudentSubjectMatterRequestDTO
{
    [Required(ErrorMessage = "Student ID is required.")]
    [Display(Name = "Student ID",
    Description = "Select the student's ID.")]
    [Range(1, 999999, ErrorMessage = "StudentId must be between 1 and 999999.")]
    public int StudentId { get; set; }
    [Required(ErrorMessage = "Subject Matter ID is required.")]
    [Display(Name = "SubjectMatter ID",
    Description = "Select the subject matter.")]
    [Range(1, 999999,
    ErrorMessage = "Subject Matter ID must be between 1 and 999999.")]
    public int SubjectMatterId { get; set; }
    [Required(ErrorMessage = "First grade is required.")]
    [Display(Name = "FirstGrade",
    Description = "Enter the first grade.")]
    [Range(0, 10,
    ErrorMessage = "FirstGrade must be between 0 and 10.")]
    public decimal RecordGradeOne { get; set; }
    [Required(ErrorMessage = "SecondGrade is required.")]
    [Display(Name = "SecondGrade",
    Description = "Enter the second grade.")]
    [Range(0, 10,
    ErrorMessage = "SecondGrade must be between 0 and 10.")]
    public decimal RecordGradeTwo { get; set; }
}
