using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Application.Features.SportPlaygrounds.Commands
{
    public class CreateSportPlaygroundCommand : IRequest<bool>
    {
        public string SportPlaygroundName { get; set; }
        public string Base64Image { get; set; }
        public IEnumerable<Guid> AvailableActivitiesIds { get; set; }

        public class CreateSportPlaygroundCommandHandler : IRequestHandler<CreateSportPlaygroundCommand, bool>
        {
            private readonly ISportPlaygroundRepository _sportPlaygroundRepository;
            private readonly ISportActivityRepository _sportActivityRepository;
            public CreateSportPlaygroundCommandHandler (ISportPlaygroundRepository sportPlaygroundRepository, ISportActivityRepository sportActivityRepository)
            {
                _sportPlaygroundRepository = sportPlaygroundRepository;
                _sportActivityRepository = sportActivityRepository;
            }

            public async Task<bool> Handle(CreateSportPlaygroundCommand command, CancellationToken cancellationToken)
            {
                var activities = command.AvailableActivitiesIds
                    .Select(async id => await _sportActivityRepository.GetByIdAsync(id))
                    .Select(t => t.Result)
                    .ToList();
                var image = new Image { Base64Data = command.Base64Image };
                var sportPlayground = new SportPlayground()
                {
                    Name = command.SportPlaygroundName,
                    SportActivities = activities,
                    Image = image
                };

                var result = await _sportPlaygroundRepository.AddAsync(sportPlayground);

                return result;
            }
        }
    }
}
