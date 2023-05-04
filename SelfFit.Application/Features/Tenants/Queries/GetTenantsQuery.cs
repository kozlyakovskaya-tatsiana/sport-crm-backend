using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.Tenants.Queries
{
    public class GetTenantsQuery : IRequest<IEnumerable<Tenant>>
    {
        public class GetTenantsQueryHandler: IRequestHandler<GetTenantsQuery, IEnumerable<Tenant>>
        {
            private readonly ITenantRepository _tenantRepository;

            public GetTenantsQueryHandler(ITenantRepository tenantRepository)
            {
                _tenantRepository = tenantRepository;
            }

            public async Task<IEnumerable<Tenant>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
            {
                return await _tenantRepository.GetAllAsync();
            }
        }
    }
}
