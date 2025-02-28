using Domain.Models;
using FluentValidation;

namespace Domain.Validation;

public class SubjectValidate : AbstractValidator<Subject>
{
    public SubjectValidate()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}