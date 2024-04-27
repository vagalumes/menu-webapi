using Application.Shared.Models.Errors;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItemsImages.v1.CreateMenuItemImageUseCase
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateMenuItemImage useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost("/{id:guid}/menu-items/{menuItemId:guid}/upload-images")]
        public async Task<IActionResult> Post(Guid id, Guid menuItemId, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, menuItemId, files, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.MenuNotFound() => _viewModel = NotFound(new NotFoundError("Menu não encontrado", HttpContext));

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound(new NotFoundError("Restaurante não encontrado", HttpContext));

        void IOutputPort.ImageSaved() => _viewModel = Created();
    }
}
