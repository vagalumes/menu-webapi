using Application.Shared.Models.Errors;
using Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Users.DeleteUserUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController(IDeleteUserUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> Delete(Guid userId, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(userId, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.UserDeleted() => _viewModel = NoContent();

        void IOutputPort.UserNotFound() => _viewModel = NotFound(new NotFoundError("Usuário não encontrado", HttpContext));
    }
}
