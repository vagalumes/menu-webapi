using Application.Shared.Models.Errors;
using Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cardapio_webapi.Controllers.Users.DeleteUserUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;
        private readonly IDeleteUserUseCase _useCase;

        public UsersController(IDeleteUserUseCase useCase) => _useCase = useCase;

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> Delete(Guid userId, CancellationToken cancellationToken)
        {
            _useCase.SetOutputPort(this);
            await _useCase.ExecuteAsync(userId, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.UserDeleted() => _viewModel = NoContent();

        void IOutputPort.UserNotFound() => _viewModel = NotFound(new NotFoundError("Usuário não encontrado", HttpContext));
    }
}
