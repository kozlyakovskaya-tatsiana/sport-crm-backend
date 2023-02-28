using FluentValidation;
using SelfFit.WebApi.Models.Authentication;

namespace SelfFit.WebApi.Validators.Authentication
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(model => model.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(model => model.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
