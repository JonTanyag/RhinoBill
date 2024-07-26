using FluentValidation;

namespace RhinoBill.Application;

public class StudentValidator : AbstractValidator<StudentDto>
{
    public StudentValidator()
    {
        RuleFor(s => s.FirstName).NotEmpty().WithMessage("Name is required.")
                .Length(2, 30).WithMessage("Name must be between 2 and 30 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("Name must contain only alphabet characters.");

        RuleFor(s => s.LastName).NotEmpty().WithMessage("Name is required.")
                .Length(2, 30).WithMessage("Name must be between 2 and 30 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("Name must contain only alphabet characters.");

        RuleFor(s => s.Email).EmailAddress().WithMessage("Email must be a valid email address.")
            .When(s => !string.IsNullOrEmpty(s.Email));
    }
}
