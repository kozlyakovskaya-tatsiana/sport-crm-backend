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
            private readonly ISportActivityRepository _sportActivityRepository;

            public GetActivitiesQueryHandler(ISportActivityRepository sportActivityRepository)
            {
                _sportActivityRepository = sportActivityRepository;
            }

            public async Task<IEnumerable<SportActivity>> Handle(GetActivitiesQuery query,
                CancellationToken cancellationToken)
            {
                return await _sportActivityRepository.GetAllAsync();
            }
        }
    }
}
