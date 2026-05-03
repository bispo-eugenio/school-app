using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class StudentValidator
: AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(x => x.Name)
        .NotNull()
        .Length(4, 100)
        .Matches(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{4,100}$")
        .WithMessage("Student name must contain only letters.");

        RuleFor(x => x.Cpf)
        .NotNull()
        .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
        .WithMessage("Student CPF must be in format 000.000.000-00");

        RuleFor(x => x.Age)
        .NotNull()
        .ExclusiveBetween(18, 140)
        .WithMessage("Age must be between 18 and 140.");

        RuleFor(x => x.CourseId)
        .ExclusiveBetween(1, 999999)
        .NotNull()
        .WithMessage("Course Id must be between 1 and 999999.");
    }
}
