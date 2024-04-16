using Application.Shared.Entities;
using Application.Shared.Models.Errors;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItems.GetMenuItemUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(IGetMenuItemUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpGet("{id:guid}/menu-item/{menuItemId:guid}")]
        public async Task<IActionResult> GetMenuItem(Guid id, Guid menuItemId, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, menuItemId, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.MenuItemNotFound() =>
            _viewModel = NotFound(new NotFoundError("Item não localizado", HttpContext));

        void IOutputPort.MenuItemFound(MenuItemResponse menuItem) => _viewModel = Ok(menuItem);

        void IOutputPort.RestaurantNotFound() =>
            _viewModel = NotFound(new NotFoundError("Restaurante não localizado", HttpContext));
    }
}
