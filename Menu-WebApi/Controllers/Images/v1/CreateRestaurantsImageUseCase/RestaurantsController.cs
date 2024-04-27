using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Images.v1.CreateRestaurantsImageUseCase
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateRestaurantImageUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost("{id:guid}/upload-images")]
        public async Task<IActionResult> Post(Guid id, IFormFile file, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, file, cancellationToken);

            return _viewModel!;
        }

        void IOutputPort.ImagesSaved() => _viewModel = Ok();

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound();
    }
}