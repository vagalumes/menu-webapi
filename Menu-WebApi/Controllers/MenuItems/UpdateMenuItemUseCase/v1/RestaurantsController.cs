using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItems.UpdateMenuItemUseCase.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class RestaurantsController(IUpdateMenuItemUseCase useCase, Notification notification)
    : ControllerBase, IOutputPort
{
    private IActionResult? _viewModel;

    [HttpPatch("{id:guid}/menu-item/{menuItemId:guid}")]
    public async Task<IActionResult> Post(Guid id, Guid menuItemId, UpdateMenuItemRequest request,
        CancellationToken cancellationToken)
    {
        useCase.SetOutputPort(this);
        await useCase.ExecuteAsync(id, menuItemId, request, cancellationToken);
        return _viewModel!;
    }

    void IOutputPort.MenuitemUpdated() => _viewModel = Ok();

    void IOutputPort.InvalidRequest() => _viewModel = BadRequest(new ValidationError(notification, HttpContext));

    void IOutputPort.MenuItemNotFound() =>
        _viewModel = NotFound(new NotFoundError("Prato não localizado", HttpContext));

    void IOutputPort.RestaurantNotFound() =>
        _viewModel = NotFound(new NotFoundError("Restaurante não encontrado!", HttpContext));
}