using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SelfFit.Application.Repositories;

namespace SelfFit.Application.Features.Activities.Commands
{
    public class DeleteActivityCommand : IRequest<bool>
    {
        public Guid ActivityId { get; set; }

        public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, bool>
        {
            private readonly ISportActivityRepository _sportActivityRepository;

            public DeleteActivityCommandHandler(ISportActivityRepository sportActivityRepository)
            {
                _sportActivityRepository = sportActivityRepository;
            }

            public async Task<bool> Handle(DeleteActivityCommand command, CancellationToken cancellationToken)
            {
                return await _sportActivityRepository.DeleteAsync(command.ActivityId);
            }
        }
    }
    public class DeleteActivityCommandValidator : AbstractValidator<DeleteActivityCommand>
    {
        public DeleteActivityCommandValidator()
        {
            RuleFor(com => com.ActivityId).NotNull().NotEmpty();
        }
    }
}
