using Joyle.Accounts.Application.UserRegistrations.RegisterNewUser;
using Joyle.API.Modules.Accounts.UserRegistrations.Requests;
using Joyle.BuildingBlocks.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Joyle.API.Modules.Accounts.UserRegistrations
{
    [Route("api/accounts/user-registrations")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public UserRegistrationsController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterNewUser(RegisterNewUserRequest request)
        {
            await _mediator.ExecuteCommandAsync(new RegisterNewUserCommand(
                request.Username,
                request.FullName,
                request.Email,
                request.Password,
                request.ConfirmationLink));

            return Ok();
        }
    }
}
