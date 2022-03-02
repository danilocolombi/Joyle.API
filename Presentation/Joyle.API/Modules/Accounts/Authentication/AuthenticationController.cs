using Joyle.Accounts.Application.Authentication.Authenticate;
using Joyle.API.Configuration.Authentication.Services;
using Joyle.API.Modules.Accounts.Authentication.Requests;
using Joyle.BuildingBlocks.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Joyle.API.Modules.Accounts.Authentication
{
    [Route("api/accounts/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public AuthenticationController(IMediatorHandler mediator, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _mediator = mediator;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var autenticacaoResult = await _mediator.ExecuteCommandAsync(new AuthenticateCommand(
                request.Email,
                request.Password));

            if (!autenticacaoResult.Success)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = autenticacaoResult.AuthenticationError
                });
            }

            return Ok(new
            {
                Success = true,
                Data = new
                {
                    Token = _jwtTokenGeneratorService.Generate(autenticacaoResult.User),
                    User = autenticacaoResult.User
                }
            });
        }
    }
}
