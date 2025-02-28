using FluentValidation;
using System.Data;
using Domain.Models;

namespace Domain.Validation;

public class CourseValidate : AbstractValidator<Course>
{
    public CourseValidate()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
    }
}