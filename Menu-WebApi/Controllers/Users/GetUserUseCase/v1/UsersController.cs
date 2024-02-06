using Application.Shared.Models.Errors;
using Application.UseCases.Users.v1.GetUserUseCase.Abstractions;
using Application.UseCases.Users.v1.GetUserUseCase.Model;
using Microsoft.AspNetCore.Mvc;

namespace Menu_WebApi.Controllers.Users.GetUserUseCase.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController(IGetUserUseCase useCase) : ControllerBase, IOutputPort
    {
        private IActionResult? _view;

        [HttpGet("{userId:Guid}")]
        public async Task<IActionResult> Get(Guid userId, CancellationToken cancellationToken)
        {
            useCase.SetOutputPort(this);
            await useCase.ExecuteAsync(userId, cancellationToken);
            return _view!;
        }

        void IOutputPort.UserFound(GetUserModel userModel) => _view = Ok(userModel);

        void IOutputPort.UserNotFound() => _view = NotFound(new NotFoundError("Usuário não localizado", HttpContext));
    }
}