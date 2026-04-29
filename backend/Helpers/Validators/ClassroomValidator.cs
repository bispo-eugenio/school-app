using FluentValidation;
using schoolApi.Models;

namespace schoolApi.Helpers.Validators;

public class ClassroomValidator : AbstractValidator<Classroom>
{
    public ClassroomValidator()
    {
        RuleFor(x => x.Name)
        .NotNull()
        .Length(4, 10)
        .WithMessage("Classroom name must be between 4 and 10 characters.");
    }
}
