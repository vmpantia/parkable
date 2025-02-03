using MediatR;
using Parkable.Shared.Models;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Owners.Queries
{
    public sealed class GetOwnersQuery : IRequest<Result<IEnumerable<OwnerDto>, Error>> { }
}
