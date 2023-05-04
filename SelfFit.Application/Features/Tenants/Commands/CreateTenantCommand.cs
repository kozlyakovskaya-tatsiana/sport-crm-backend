using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.Tenants.Commands
{
    public class CreateTenantCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public DateTimeOffset ContractStartDate { get; set; }
        public DateTimeOffset ContractEndDate { get; set; }

        public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, bool>
        {
            private readonly ITenantRepository _tenantRepository;

            public CreateTenantCommandHandler(ITenantRepository tenantRepository)
            {
                _tenantRepository = tenantRepository;
            }

            public async Task<bool> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
            {
                var tenant = new Tenant
                {
                    Name = request.Name,
                    Contract = new Contract
                    {
                        StartDate = request.ContractStartDate,
                        EndDate = request.ContractEndDate,
                    }
                };

                return await _tenantRepository.AddAsync(tenant);
            }
        }
    }
}
