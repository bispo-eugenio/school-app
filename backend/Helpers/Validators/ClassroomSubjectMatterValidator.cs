using System.Data;
using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class ClassroomSubjectMatterValidator :
AbstractValidator<ClassroomSubjectMatter>
{
    public ClassroomSubjectMatterValidator()
    {
        RuleFor(x => x.ClassroomId)
        .NotEmpty()
        .NotNull()
        .ExclusiveBetween(1, 999999)
        .WithMessage("Classroom Id must be between 1 and 999999.");

        RuleFor(x => x.SubjectMatterId)
        .NotEmpty()
        .NotNull()
        .ExclusiveBetween(1, 999999)
        .WithMessage("Subject Matter Id must be between 1 and 999999.");

        RuleFor(x => x.Day)
        .Length(6, 10)
        .NotEmpty()
        .Matches(@"^[a-zA-Z''-'\s]{6,9}$")
        .WithMessage("Day must contain only letters.");

        RuleFor(x => x.StartedAt)
        .NotEmpty()
        .NotNull()
        .WithMessage("Started At must be in format 00:00:00");

        RuleFor(x => x.EndedAt)
        .NotEmpty()
        .NotNull()
        .WithMessage("Ended At must be in format 00:00:00");

        RuleFor(x => x.Details)
        .Null()
        .MaximumLength(1000)
        .MinimumLength(10)
        .WithMessage("Classroom Subject Matter details" +
        " must be between 10 and 1000 characters.");
    }
}
