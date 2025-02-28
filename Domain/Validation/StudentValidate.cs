using System.Data;
using Domain.Models;
using FluentValidation;

namespace Domain.Validation;

public class StudentValidate : AbstractValidator<Student>
{
    public StudentValidate()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth cannot be empty");
        RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Photo cannot be empty");
    }
}