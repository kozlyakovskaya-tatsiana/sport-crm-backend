using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;

namespace SelfFit.Application.Features.SportPlaygrounds.Commands
{
    public class DeleteSportPlaygroundCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class DeleteSportPlaygroundCommandHandler : IRequestHandler<DeleteSportPlaygroundCommand, bool>
        {
            private readonly ISportPlaygroundRepository _sportPlaygroundRepository;

            public DeleteSportPlaygroundCommandHandler(ISportPlaygroundRepository sportPlaygroundRepository)
            {
                _sportPlaygroundRepository = sportPlaygroundRepository;
            }

            public async Task<bool> Handle(DeleteSportPlaygroundCommand command, CancellationToken cancellationToken)
            {
                return await _sportPlaygroundRepository.DeleteAsync(command.Id);
            }
        }
    }
}
