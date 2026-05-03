using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class SubjectMatterValidator
: AbstractValidator<SubjectMatter>
{

    public SubjectMatterValidator()
    {
        RuleFor(x => x.Name)
        .NotNull()
        .Length(3, 100)
        .Matches(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,100}$")
        .WithMessage("Subject Matter name must contain only letters.");

        RuleFor(x => x.Details)
        .Null()
        .Length(10, 1000)
        .WithMessage("Course details must be between 10 and 1000 characters.");

        RuleFor(x => x.TeacherId)
        .Null()
        .ExclusiveBetween(1, 999999)
        .WithMessage("Teacher Id must be between 10 and 1000.");

    }

}
