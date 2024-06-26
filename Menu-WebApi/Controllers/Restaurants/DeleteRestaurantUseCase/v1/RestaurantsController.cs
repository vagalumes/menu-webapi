﻿using Application.Shared.Models.Errors;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Restaurants.DeleteRestaurantUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RestaurantsController(IDeleteRestaurantUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRestaurant(Guid id, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(id, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.RestaurantDeleted() => _viewModel = NoContent();

        void IOutputPort.RestaurantNotFound() => _viewModel = NotFound(new NotFoundError("Restaurante não encontrado", HttpContext));
    }
}
