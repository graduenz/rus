using FluentValidation;
using FluentValidation.Validators;

namespace Advertiser.Application;

public class AdvertiserDtoValidator : AbstractValidator<AdvertiserDto>
{
    public AdvertiserDtoValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MinimumLength(3);
        RuleFor(m => m.Email).EmailAddress().When(m => m.Email is not null);
    }
}