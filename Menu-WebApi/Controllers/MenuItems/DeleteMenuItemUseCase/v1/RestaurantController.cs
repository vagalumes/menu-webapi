using Application.Shared.Models.Errors;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItems.DeleteMenuItemUseCase.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class RestaurantController(IDeleteMenuItemUseCase useCase) : ControllerBase, IOutputPort
{
    private IActionResult? _viewModel;

    [HttpDelete("{id:guid}/menu-item/{menuItemId:guid}")]
    public async Task<IActionResult> DeleteMenuItem(Guid id, Guid menuItemId, CancellationToken cancellationToken)
    {
        useCase.SetOutputPort(this);
        await useCase.ExecuteAsync(id, menuItemId, cancellationToken);
        return _viewModel!;
    }

    void IOutputPort.RestaurantNotFound() =>
        _viewModel = NotFound(new NotFoundError("Restaurante não encontrado", HttpContext));

    void IOutputPort.MenuItemNotFound() =>
        _viewModel = NotFound(new NotFoundError("Prato não localizado", HttpContext));

    void IOutputPort.MenuItemDeleted() => _viewModel = NoContent();
}