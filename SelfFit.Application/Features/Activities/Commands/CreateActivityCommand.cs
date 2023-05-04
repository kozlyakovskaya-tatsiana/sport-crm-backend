using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SelfFit.Application.Exceptions;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.Activities.Commands
{
    public class CreateActivityCommand : IRequest<bool>
    {
        public string ActivityName { get; set; }
        public decimal CostPerHourInByn { get; set; }

        public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, bool>
        {
            private readonly ISportActivityRepository _sportActivityRepository;

            public CreateActivityCommandHandler(ISportActivityRepository sportActivityRepository)
            {
                _sportActivityRepository = sportActivityRepository;
            }

            public async Task<bool> Handle(CreateActivityCommand command, CancellationToken cancellationToken)
            {
                var isActivityAlreadyExisted = await IsActivityWithSpecifiedNameExists(command.ActivityName);
                if (isActivityAlreadyExisted)
                {
                    throw new AlreadyExistsException();
                }
                var activityToAdd = new SportActivity()
                {
                    Name = command.ActivityName,
                    CostPerHourInByn = command.CostPerHourInByn
                };
                return await _sportActivityRepository.AddAsync(activityToAdd);
            }

            private async Task<bool> IsActivityWithSpecifiedNameExists(string sportActivityName)
            {
                return await _sportActivityRepository.Exist(activity => activity.Name == sportActivityName);
            }
        }
    }
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(com => com.ActivityName).NotNull().NotEmpty();
            RuleFor(com => com.CostPerHourInByn).NotNull().NotEmpty();
        }
    }
}
