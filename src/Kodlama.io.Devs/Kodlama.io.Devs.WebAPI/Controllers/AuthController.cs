using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.CreateAppUser;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]  CreateAppUserCommand createAppUserCommand)
        {
            var result = await Mediator.Send(createAppUserCommand);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserCommand loginAppUserCommand)
        {
            var result = await Mediator.Send(loginAppUserCommand);
            return Ok(result);
        }
    }
}
