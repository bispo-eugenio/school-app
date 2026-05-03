using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class CourseSubjectMatterValidator
: AbstractValidator<CourseSubjectMatter>
{
    public CourseSubjectMatterValidator()
    {
        RuleFor(x => x.CourseId)
        .NotEmpty()
        .NotNull()
        .ExclusiveBetween(1, 999999)
        .WithMessage("Course Id must be between 1 and 999999.");

        RuleFor(x => x.SubjectMatterId)
        .NotEmpty()
        .NotNull()
        .ExclusiveBetween(1, 999999)
        .WithMessage("Course Id must be between 1 and 999999.");

        RuleFor(x => x.IsActived)
        .NotNull()
        .ExclusiveBetween(0, 1)
        .WithMessage("IsActived must be between 0 and 1.");

        RuleFor(x => x.WorkloadHours)
        .NotNull()
        .ExclusiveBetween(1, 100)
        .WithMessage("WorkloadHours must be between 1 and 100.");

        RuleFor(x => x.IsMandatory)
        .NotNull()
        .ExclusiveBetween(0, 1)
        .WithMessage("IsMandatory must be between 0 and 1.");

        RuleFor(x => x.Semester)
        .NotNull()
        .ExclusiveBetween(1, 100)
        .WithMessage("Semester must be between 1 and 100.");

        RuleFor(x => x.Details)
        .Null()
        .Length(10, 1000)
        .WithMessage("Course details must be between 10 and 1000 characters.");
    }
}
