using FluentValidation;

namespace ECommerceCart.Application.UserCommandQuery.Command.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(10);
    }
}