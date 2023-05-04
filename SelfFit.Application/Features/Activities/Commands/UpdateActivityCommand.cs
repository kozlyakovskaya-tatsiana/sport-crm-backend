using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.Activities.Commands
{
    public class UpdateActivityCommand : IRequest<bool>
    {
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public decimal CostPerHourInByn { get; set; }

        public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, bool>
        {
            private readonly ISportActivityRepository _sportActivityRepository;

            public UpdateActivityCommandHandler(ISportActivityRepository sportActivityRepository)
            {
                _sportActivityRepository = sportActivityRepository;
            }

            public async Task<bool> Handle(UpdateActivityCommand command, CancellationToken cancellationToken)
            {
                return await _sportActivityRepository.UpdateAsync(new SportActivity
                {
                    Id = command.ActivityId,
                    Name = command.Name,
                    CostPerHourInByn = command.CostPerHourInByn
                });
            }
        }

        public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
        {
            public UpdateActivityCommandValidator()
            {
                RuleFor(com => com.ActivityId).NotNull().NotEmpty();
                RuleFor(com => com.Name).NotNull().NotEmpty();
                RuleFor(com => com.CostPerHourInByn).NotNull().NotEmpty();
            }
        }
    }
}
