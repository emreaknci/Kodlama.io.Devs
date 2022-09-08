using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyValidator:AbstractValidator<CreateTechnologyCommand>
{
    public CreateTechnologyValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(1);
    }
}