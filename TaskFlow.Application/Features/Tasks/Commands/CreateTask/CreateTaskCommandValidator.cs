using FluentValidation;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");
            
            RuleFor(x => x.Status)
                .Must(s => s == "New" || s == "InProgress" || s == "Done")
                .WithMessage("Invalid status");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty");
    }
}
