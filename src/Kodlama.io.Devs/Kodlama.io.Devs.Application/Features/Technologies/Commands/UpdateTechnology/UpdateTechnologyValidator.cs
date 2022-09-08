using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyValidator:AbstractValidator<UpdateTechnologyCommand>
{
    public UpdateTechnologyValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(1);
    }
}