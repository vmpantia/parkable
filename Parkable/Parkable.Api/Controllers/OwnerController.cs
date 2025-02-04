﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parkable.Core.Owners.Queries;

namespace Parkable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : BaseController
    {
        public OwnerController(IMediator mediator) : base(mediator) { }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetOwnersAsync() => await SendRequestAsync(new GetOwnersQuery());

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetOwnersAsync(Guid id) => await SendRequestAsync(new GetOwnerByIdQuery(id));
    }
}
