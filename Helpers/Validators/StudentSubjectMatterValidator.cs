using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class StudentSubjectMatterValidator
: AbstractValidator<StudentSubjectMatter>
{

    public StudentSubjectMatterValidator()
    {
        RuleFor(x => x.StudentId)
        .InclusiveBetween(1, 999999)
        .NotNull()
        .WithMessage("Student Id must be between 1 and 999999.");

        RuleFor(x => x.SubjectMatterId)
        .InclusiveBetween(1, 999999)
        .NotNull()
        .WithMessage("Subject Matter Id must be between 1 and 999999.");

        RuleFor(x => x.FirstGrade)
        .InclusiveBetween(0, 10)
        .NotNull()
        .WithMessage("First Grade must be between 0 and 10.");

        RuleFor(x => x.SecondGrade)
        .InclusiveBetween(0, 10)
        .NotNull()
        .WithMessage("Second Grade must be between 0 and 10.");

    }

}
