using Joyle.Accounts.Application.PasswordRecoveries.RecoverPassword;
using Joyle.Accounts.Application.PasswordRecoveries.RequestPasswordRecovery;
using Joyle.API.Modules.Accounts.PasswordRecoveries.Requests;
using Joyle.BuildingBlocks.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Joyle.API.Modules.Accounts.PasswordRecoveries
{
    [Route("api/accounts/password-recoveries")]
    [ApiController]
    public class PasswordRecoveriesController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public PasswordRecoveriesController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterNewUser(RequestPasswordRecoveryRequest request)
        {
            await _mediator.ExecuteCommandAsync(new RequestPasswordRecoveryCommand(
                request.Email,
                request.RecoveryLink));

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("recover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordRequest request)
        {
            await _mediator.ExecuteCommandAsync(new RecoverPasswordCommand(
                request.PasswordRecoveryId,
                request.Password));

            return Ok();
        }
    }
}
