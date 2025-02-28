using Domain.Models;
using FluentValidation;

namespace Domain.Validation;

public class GroupValidate : AbstractValidator<Group>
{
    public GroupValidate()
    {
        RuleFor(group => group.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(group => group.Description).NotEmpty().WithMessage("Description cannot be empty");
    }
}