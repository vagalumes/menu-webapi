using Application.Shared.Models.Errors;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Images.v1.CreateMenuItemImageUseCase
{
    [Route("api/v{version:apiVersion}/[controller]/menu/{id:guid}/upload-image")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateMenuItemImage useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, files, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.MenuNotFound() => _viewModel = NotFound(new NotFoundError("Menu não encontrado", HttpContext));

        void IOutputPort.ImageSaved() => _viewModel = Created();
    }
}
