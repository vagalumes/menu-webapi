using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase.Abstractions;

public interface ICreateUserImageUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken);
}