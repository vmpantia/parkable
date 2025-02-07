using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parkable.Core.Users.Commands;
using Parkable.Shared.Models;

namespace Parkable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator) { }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginDto dto) => await SendRequestAsync(new LoginCommand(dto));
    }
}
