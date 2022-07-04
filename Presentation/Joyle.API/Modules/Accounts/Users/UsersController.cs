using Joyle.Accounts.Application.Users.ActivateUser;
using Joyle.Accounts.Application.Users.ChangeUsername;
using Joyle.Accounts.Application.Users.ChangeUserPassword;
using Joyle.Accounts.Application.Users.GetUser;
using Joyle.Accounts.Application.Users.InactivateUser;
using Joyle.API.Configuration.Authentication.Services;
using Joyle.API.Modules.Accounts.Users.Requests;
using Joyle.BuildingBlocks.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Joyle.API.Modules.Accounts.Users
{
    [Route("api/accounts/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _aspNetUser;

        public UsersController(IMediatorHandler mediator, IAspNetUser aspNetUser)
        {
            _mediator = mediator;
            _aspNetUser = aspNetUser;
        }

        [HttpPatch("inactivation")]
        public async Task<IActionResult> Inactivate()
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new InactivateUserCommand(id));

            return Ok();
        }

        [HttpPatch("activation")]
        public async Task<IActionResult> Activate()
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ActivateUserCommand(id));

            return Ok();
        }

        [HttpPatch("username")]
        public async Task<IActionResult> ChangeUsername(ChangeUsernameRequest request)
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ChangeUsernameCommand(
                id,
                request.Username));

            return Ok();
        }

        [HttpPatch("password")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordRequest request)
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ChangeUserPasswordCommand(
                id,
                request.CurrentPassword,
                request.NewPassword));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var id = _aspNetUser.GetId();

            var usuario = await _mediator.ExecuteQueryAsync(new GetUserQuery(id));

            return Ok(usuario);
        }
    }
}
