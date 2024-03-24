using Application.Shared.Entities;
using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItems.CreateMenuItemUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]/{id:guid}/menuItem")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateMenuItemsUseCase useCase, Notification notification) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] CreateMenuItemsRequest request, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, request, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.InvalidRequest() => _viewModel = NotFound(new ValidationError(notification, HttpContext));

        void IOutputPort.MenuItemsCreated(MenuItem menuItem) => _viewModel = Created($"api/v1/menuItems/{menuItem.Id}", menuItem);

        void IOutputPort.RestaurantNotFound(string message) => _viewModel = NotFound(new NotFoundError(message, HttpContext));
    }
}
