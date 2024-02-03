﻿using Application.Shared.Notifications;
using Application.UseCases.Users.v1.UpdateUserUsecase.Abstraction;
using Application.UseCases.Users.v1.UpdateUserUsecase.Models;
using Application.UseCases.Users.v1.UpdateUserUsecase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.UpdateUserUsecase
{
    public class UpdateUserValidationUseCase(IUserRepository repository, IUpdateUserUseCase useCase, Notification notification) : IUpdateUserUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(outputPort);
        }

        public async Task ExecuteAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var checkUser = repository.GetUser(userId, cancellationToken);

            if (checkUser is not null)
                notification.AddErrorMessage(nameof(userId), "Usuário não localizado");

            if (notification.IsInvalid)
            {
                _outputPort!.InvalidRequest();
                return;
            }

            await useCase.ExecuteAsync(userId, request, cancellationToken);
        }
    }
}
