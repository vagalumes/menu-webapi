using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Images.v1.CreateRestaurantsImageUseCase
{
    [Route("api/v{version:apiVersion}/[controller]/{id:guid}/upload-image")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateImageUseCase useCase) : ControllerBase, IOutputPort
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

        void IOutputPort.ImagesSaved(IEnumerable<FileInfo> filesInfos) => _viewModel = Created($"api/v1/restaurant/upload-image/{filesInfos.FirstOrDefault().DirectoryName}", filesInfos);

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound();
    }
}
