using FluentValidation;

namespace Advertiser.Application.Advertiser;

public class AdvertiserDtoValidator : AbstractValidator<AdvertiserDto>
{
    public AdvertiserDtoValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MinimumLength(3);
        RuleFor(m => m.Email).EmailAddress().When(m => m.Email is not null);
    }
}