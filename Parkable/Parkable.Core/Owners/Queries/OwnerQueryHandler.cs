using AutoMapper;
using MediatR;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Shared.Models.Owners;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Owners.Queries
{
    public class OwnerQueryHandler : 
        IRequestHandler<GetOwnersQuery, Result<IEnumerable<OwnerDto>, Error>>,
        IRequestHandler<GetOwnerByIdQuery, Result<OwnerDto, Error>>
    { 
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerQueryHandler(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<OwnerDto>, Error>> Handle(GetOwnersQuery request, CancellationToken cancellationToken)
        {
            // Get owners from the database
            var owners = await _ownerRepository.GetOwnersAsync(cancellationToken);

            // Convert owners to dto
            var result = owners.Select(_mapper.Map<OwnerDto>)
                               .ToList();

            return result;
        }

        public async Task<Result<OwnerDto, Error>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            // Get owner using id from the database
            var owner = await _ownerRepository.GetOwnerByIdAsync(request.Id, cancellationToken);

            // Check if owner not exist or found
            if (owner is null) return OwnerError.NotFound(request.Id);

            // Convert owner to dto
            var result = _mapper.Map<OwnerDto>(owner);

            return result;
        }
    }
}
