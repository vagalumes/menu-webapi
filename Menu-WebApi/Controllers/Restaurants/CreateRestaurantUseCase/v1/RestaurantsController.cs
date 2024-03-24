using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Restaurants.CreateRestaurantUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(ICreateRestaurantUseCase useCase, Notification notification) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(request, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.InvalidRequest() => _viewModel = NotFound(new ValidationError(notification, HttpContext));

        void IOutputPort.RestaurantCreated(RestaurantDto restaurant) => _viewModel = Created($"api/v1/restaurants/{restaurant.Id}", restaurant);
    }
}
