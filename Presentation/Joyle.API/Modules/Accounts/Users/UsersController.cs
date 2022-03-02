using Joyle.Accounts.Application.Users.ChangeUsername;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _aspNetUser;

        public UsersController(IMediatorHandler mediator, IAspNetUser aspNetUser)
        {
            _mediator = mediator;
            _aspNetUser = aspNetUser;
        }

        [HttpPut("inactive")]
        [Authorize]
        public async Task<IActionResult> Inactivate()
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new InactivateUserCommand(id));

            return Ok();
        }

        [HttpPut("username")]
        [Authorize]
        public async Task<IActionResult> ChangeUsername(ChangeUsernameRequest request)
        {
            var id = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ChangeUsernameCommand(
                id,
                request.Username));

            return Ok();
        }
    }
}
