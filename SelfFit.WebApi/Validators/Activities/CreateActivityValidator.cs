using FluentValidation;
using SelfFit.WebApi.Models.Activity;

namespace SelfFit.WebApi.Validators.Activities
{
    public class CreateActivityValidator : AbstractValidator<CreateActivityRequest>
    {
        public CreateActivityValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
            RuleFor(model => model.CostPerHour).NotNull().NotEmpty();
        }
    }
}
