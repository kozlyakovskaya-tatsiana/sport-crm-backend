using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.SportPlaygrounds.Queries
{
    public class GetSportPlaygroundsQuery : IRequest<IEnumerable<SportPlayground>>
    {
        public class GetSportPlaygroundsQueryHandler : IRequestHandler<GetSportPlaygroundsQuery, IEnumerable<SportPlayground>>
        {
            private readonly ISportPlaygroundRepository _sportPlaygroundRepository;

            public GetSportPlaygroundsQueryHandler(ISportPlaygroundRepository sportPlaygroundRepository)
            {
                _sportPlaygroundRepository = sportPlaygroundRepository;
            }

            public async Task<IEnumerable<SportPlayground>> Handle(GetSportPlaygroundsQuery request, CancellationToken cancellationToken)
            {
                return await _sportPlaygroundRepository.GetAllAsync();
            }
        }
    }
}
