using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.Activities.Queries
{
    public class GetActivitiesQuery : IRequest<IEnumerable<SportActivity>>
    {
        public class GetActivitiesQueryHandler: IRequestHandler<GetActivitiesQuery, IEnumerable<SportActivity>>
        {
            private readonly ISportActivitiesRepository _sportActivitiesRepository;

            public GetActivitiesQueryHandler(ISportActivitiesRepository sportActivitiesRepository)
            {
                _sportActivitiesRepository = sportActivitiesRepository;
            }

            public async Task<IEnumerable<SportActivity>> Handle(GetActivitiesQuery query,
                CancellationToken cancellationToken)
            {
                return await _sportActivitiesRepository.GetAllAsync();
            }
        }
    }
}
