using Application.Shared.Models.Errors;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Images.v1.CreateUserImageUseCase
{
    [Route("api/v{version:apiVersion}/[controller]/{id:guid}/upload-image")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController(ICreateUserImageUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromForm] IEnumerable<IFormFile> files,
            CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, files, cancellationToken);

            return _viewModel!;
        }

        void IOutputPort.UserNotFound() => _viewModel = NotFound(new NotFoundError("Usuário não encontrado", HttpContext));

        void IOutputPort.ImageSaved() => _viewModel = Created();
    }
}
