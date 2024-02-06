using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.Users.v1.UpdateUserUseCase.Abstraction;
using Application.UseCases.Users.v1.UpdateUserUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Users.UpdateUserUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController(IUpdateUserUseCase useCase, Notification notification) : ControllerBase, IOutputPort
    {
        private IActionResult? _view;

        [HttpPatch("{userId:guid}")]
        public async Task<IActionResult> Post(Guid userId, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(userId, request, cancellationToken);
            return _view!;
        }

        void IOutputPort.InvalidRequest() => _view = BadRequest(new ValidationError(notification, HttpContext));

        void IOutputPort.UserNotFound() => _view = NotFound(new NotFoundError("Usuário não localizado", HttpContext));

        void IOutputPort.UserUpdated() => _view = NoContent();
    }
}
