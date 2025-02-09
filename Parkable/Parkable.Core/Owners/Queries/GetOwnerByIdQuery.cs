﻿using MediatR;
using Parkable.Shared.Models;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;
namespace Parkable.Core.Owners.Queries
{
    public record GetOwnerByIdQuery(Guid Id) : IRequest<Result<OwnerDto, Error>> { }
}
