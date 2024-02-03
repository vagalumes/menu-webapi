using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cardapio_webapi.Controllers.Restaurants.UpdateRestaurantUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(IUpdateRestaurantUseCase useCase, Notification notification) : ControllerBase, IOutputPort
    {
        private IActionResult? _view;

        [HttpPatch("{restaurantId:guid}")]
        public async Task<IActionResult> Post(Guid restaurantId, [FromBody] UpdateRestaurantRequest request, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(restaurantId, request, cancellationToken);
            return _view!;
        }

        void IOutputPort.InvalidRequest() => _view = BadRequest(new ValidationError(notification, HttpContext));

        void IOutputPort.RestaurantNotFound() => _view = NotFound(new NotFoundError("Restaurant não encontrado", HttpContext));

        void IOutputPort.RestaurantUpdated() => _view = NoContent();
    }
}
