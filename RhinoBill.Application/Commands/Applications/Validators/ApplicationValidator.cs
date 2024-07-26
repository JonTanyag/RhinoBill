using FluentValidation;

namespace RhinoBill.Application;

public class ApplicationValidator : AbstractValidator<ApplicationDto>
{
    public ApplicationValidator()
    {
        RuleFor(a => a.StudentId).NotEmpty().WithMessage("StudentId is required.");
        RuleFor(a => a.CourseId).NotEmpty().WithMessage("CourseId is required.");
        RuleFor(a => a.ApplicationDate).NotEmpty().WithMessage("ApplicationDate is required.");

    }
}
