using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser;

public class LoginAppUserValidator : AbstractValidator<LoginAppUserCommand>
{

    public LoginAppUserValidator()
    {
        RuleFor(c => c.Email).EmailAddress();
    }
}