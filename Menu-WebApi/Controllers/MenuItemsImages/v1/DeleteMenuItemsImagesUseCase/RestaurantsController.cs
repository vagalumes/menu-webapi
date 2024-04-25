using Application.Shared.Models.Errors;
using Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItemsImages.v1.DeleteMenuItemsImagesUseCase;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class RestaurantsController(IDeleteMenuItemImagesUseCase useCase) : ControllerBase, IOutputPort
{
    private IActionResult? _viewModel;

    [HttpDelete("menuItem/{id:guid}/image/{fileId:guid}")]
    public async Task<IActionResult> Index(Guid id, Guid fileId, CancellationToken cancellationToken)
    {
        useCase.SetOutputPort(this);
        await useCase.ExecuteAsync(id, fileId, cancellationToken);
        return _viewModel!;
    }

    void IOutputPort.MenuItemNotFound() =>
        _viewModel = NotFound(new NotFoundError("Prato não encontrado", HttpContext));

    void IOutputPort.MenuItemImageDeleted() => _viewModel = Ok();

    void IOutputPort.ImagesNotFound() => _viewModel = NotFound(new NotFoundError("Imagem não localizada", HttpContext));
}