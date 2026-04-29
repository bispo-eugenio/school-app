using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class CourseValidator : AbstractValidator<Course>
{

    public CourseValidator()
    {
        RuleFor(x => x.Name)
        .NotNull()
        .Length(4, 100)
        .Matches(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{4,100}$")
        .WithMessage("Course name must contain only letters.");

        RuleFor(x => x.Details)
        .Null()
        .Length(10, 1000)
        .WithMessage("Course details must be between 10 and 1000 characters.");
    }

}
