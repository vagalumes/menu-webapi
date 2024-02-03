using Application.Shared.Models.Errors;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cardapio_webapi.Controllers.Restaurants.DeleteRestaurantUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;
        private readonly IDeleteRestaurantUseCase _DeleteRestaurantUseCase;

        public RestaurantsController(IDeleteRestaurantUseCase useCase) => _DeleteRestaurantUseCase = useCase;

        [HttpDelete("{restaurantId:guid}")]
        public async Task<IActionResult> DeleteRestaurant(Guid restaurantId, CancellationToken cancellationToken)
        {
            _DeleteRestaurantUseCase.SetOutputPort(this);
            await _DeleteRestaurantUseCase.ExecuteAsync(restaurantId, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.RestaurantDeleted() => _viewModel = NoContent();

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound(new NotFoundError("Restaurante não encontrado", HttpContext));
    }
}
