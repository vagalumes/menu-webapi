using Application.Shared.Models.Errors;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.MenuItems.GetMenuItemsUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(IGetMenuItemsUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpGet("{id:guid}/menu-items")]
        public async Task<IActionResult> GetMenuItem(Guid id, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.RestaurantNotFound() =>
            _viewModel = NotFound(new NotFoundError("Restaurante não localizado", HttpContext));

        void IOutputPort.MenuItemsFound(IEnumerable<MenuItemsResponse> menuItems) => _viewModel = Ok(menuItems);
    }
}
