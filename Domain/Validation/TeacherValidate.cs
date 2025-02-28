using Domain.Models;
using FluentValidation;

namespace Domain.Validation;

public class TeacherValidate : AbstractValidator<Teacher>
{
    public TeacherValidate()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required");
        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.AcademicDegree).NotEmpty().WithMessage("AcademicDegree is required");
        RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("PhotoUrl is required");
    }
}