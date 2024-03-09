using Application.Shared.Models.Errors;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Restaurants.GetRestaurantUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(IGetRestaurantUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpGet("{restaurantId:guid}")]
        public async Task<IActionResult> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
        {
            useCase.SetOutputport(this);
            await useCase.ExecuteAsync(restaurantId, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.RestaurantFound(GetRestaurantModel restaurantModel) => _viewModel = Ok(restaurantModel);

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound(new NotFoundError("Restaurante não encontrado", HttpContext));
    }
}
