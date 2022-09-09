using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.CreateAppUser;

public class CreateAppUserValidator : AbstractValidator<CreateAppUserCommand>
{
    public CreateAppUserValidator()
    {
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
    }
}