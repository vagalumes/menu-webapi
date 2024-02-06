using Application.Shared.Models.Errors;
using Application.Shared.Notifications;
using Application.UseCases.Users.v1.CreateUserUseCase.Abstractions;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Users.CreateUserUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController(ICreateUsersUseCase useCase, Notification notification) : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(request, cancellationToken);
            return _viewModel!;
        }

        void IOutputPort.InvalidRequest() => _viewModel = NotFound(new ValidationError(notification, HttpContext));

        void IOutputPort.UserCreated(UserDto users) => _viewModel = Created($"api/v1/Users/{users.Id}", users);
    }
}