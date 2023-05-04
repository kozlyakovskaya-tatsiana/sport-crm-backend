using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.DTO.SportGroupMembers;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.SportGroups.Commands
{
    public class CreateSportGroupCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public Guid ActivityId { get; set; }
        public Guid TenantId { get; set; }
        public IEnumerable<CreateSportGroupMemberDto> Members { get; set; }

        public class CreateSportGroupCommandHandler : IRequestHandler<CreateSportGroupCommand, bool>
        {
            private readonly ISportActivityRepository _sportActivityRepository;
            private readonly ITenantRepository _tenantRepository;
            // private readonly ISportGroupMemberRepository _memberRepository;
            private readonly ISportGroupRepository _sportGroupRepository;

            public CreateSportGroupCommandHandler(
                ISportActivityRepository sportActivityRepository,
                ITenantRepository tenantRepository,
                ISportGroupRepository sportGroupRepository)
            {
                _sportActivityRepository = sportActivityRepository;
                _tenantRepository = tenantRepository;
                //_memberRepository = memberRepository;
                _sportGroupRepository = sportGroupRepository;
            }

            public async Task<bool> Handle(CreateSportGroupCommand request, CancellationToken cancellationToken)
            {
                var sportActivity = await _sportActivityRepository.GetByIdAsync(request.ActivityId);
                var tenant = await _tenantRepository.GetByIdAsync(request.TenantId);
                var sportGroup = new SportGroup
                {
                    Name = request.Name,
                    SportActivity = sportActivity,
                    Tenant = tenant,
                    Members = request.Members?.Select(m => new SportGroupMember
                    {
                        Name = m.Name,
                        MobilePhoneNumber = m.MobilePhoneNumber,
                    }).ToList()
                };

                return await _sportGroupRepository.AddAsync(sportGroup);
            }
        }
    }
}
