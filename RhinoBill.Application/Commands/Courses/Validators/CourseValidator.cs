using FluentValidation;

namespace RhinoBill.Application;

public class CourseValidator : AbstractValidator<CourseDto>
{
    public CourseValidator()
    {
        RuleFor(c => c.Title).NotEmpty().WithMessage("Title is required.")
                .Length(5, 50).WithMessage("Title must be between 5 and 50 characters.")
                .Matches(@"^[a-zA-Z0-9\s\p{P}]$").WithMessage("Title must be alphanumeric and/or contain special characters only.");

        RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required.")
            .Length(5, 10).WithMessage("Code must be between 5 and 10 characters.")
            .Matches(@"^[a-zA-Z0-9]+$").WithMessage("Code must be alphanumeric only.");

        RuleFor(c => c.Credits).GreaterThan(0).WithMessage("Credits must be more than 0.");

    }
}
