using Joyle.API.Configuration.Authentication.Services;
using Joyle.API.Modules.Games.Cardashians.Requests;
using Joyle.BuildingBlocks.Application.Mediator;
using Joyle.Games.Application.Cardashians.AddCardashianCard;
using Joyle.Games.Application.Cardashians.ChangeCardashianCardDescription;
using Joyle.Games.Application.Cardashians.ChangeCardashianCardPosition;
using Joyle.Games.Application.Cardashians.CreateCardashian;
using Joyle.Games.Application.Cardashians.DeleteCardashian;
using Joyle.Games.Application.Cardashians.RemoveCardashianCard;
using Joyle.Games.Application.Cardashians.RenameCardashian;
using Joyle.Games.Application.Cardashians.TurnCardashianPrivate;
using Joyle.Games.Application.Cardashians.TurnCardashianPublic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Joyle.API.Modules.Games.Cardashians
{
    [Route("api/games/cardashians")]
    [ApiController]
    [Authorize]
    public class CardashiansController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _aspNetUser;

        public CardashiansController(IMediatorHandler mediator, IAspNetUser aspNetUser)
        {
            _mediator = mediator;
            _aspNetUser = aspNetUser;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardashianRequest request)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new CreateCardashianCommand(
                request.Title,
                request.IsPublic,
                authorId));

            return Ok();
        }        

        [HttpPatch("{id:Guid}/name")]
        public async Task<IActionResult> Rename(Guid id, [FromBody] RenameCardashianRequest request)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new RenameCardashianCommand(
                id,
                authorId,
                request.Title));

            return Ok();
        }

        [HttpPatch("{id:Guid}/private")]
        public async Task<IActionResult> TurnPrivate(Guid id)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new TurnCardashianPrivateCommand(
                id,
                authorId));

            return Ok();
        }

        [HttpPatch("{id:Guid}/public")]
        public async Task<IActionResult> TurnPublic(Guid id)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new TurnCardashianPublicCommand(
                id,
                authorId));

            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new DeleteCardashianCommand(
                id,
                authorId));

            return NoContent();
        }

        [HttpPost("{id:Guid}/cards")]
        public async Task<IActionResult> AddCard(Guid id, [FromBody] AddCardashianCardRequest request)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new AddCardashianCardCommand(
                id,
                authorId,
                request.Description));

            return Ok();
        }

        [HttpPatch("{id:Guid}/cards/{cardId:Guid}/position")]
        public async Task<IActionResult> ChangeCardPosition(Guid id, Guid cardId, [FromBody] ChangeCardashianCardPositionRequest request)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ChangeCardashianCardPositionCommand(
                id,
                authorId,
                cardId,
                request.Position));

            return Ok();
        }

        [HttpPatch("{id:Guid}/cards/{cardId:Guid}/description")]
        public async Task<IActionResult> ChangeCardDescription(Guid id, Guid cardId, [FromBody] ChangeCardashianCardDescriptionRequest request)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new ChangeCardashianCardDescriptionCommand(
                id,
                authorId,
                cardId,
                request.Description));

            return Ok();
        }

        [HttpDelete("{id:Guid}/cards/{cardId:Guid}")]
        public async Task<IActionResult> RemoveCard(Guid id, Guid cardId)
        {
            var authorId = _aspNetUser.GetId();

            await _mediator.ExecuteCommandAsync(new RemoveCardashianCardCommand(
                id,
                authorId,
                cardId));

            return Ok();
        }
    }
}
