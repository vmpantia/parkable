using AutoMapper;
using MediatR;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Infra.Databases.Entities;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Owners.Commands
{
    public class OwnerCommandHandler : 
        IRequestHandler<CreateOwnerCommand, Result<string, Error>>,
        IRequestHandler<UpdateOwnerCommand, Result<string, Error>>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerCommandHandler(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<Result<string, Error>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Owner>(request);

            await _ownerRepository.CreateAsync(entity, cancellationToken);

            return "Owner created successfully.";
        }

        public async Task<Result<string, Error>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Owner>(request);

            await _ownerRepository.UpdateAsync(entity, cancellationToken);

            return "Owner updated successfully.";
        }
    }
}
