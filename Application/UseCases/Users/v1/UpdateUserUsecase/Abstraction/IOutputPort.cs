﻿namespace Application.UseCases.Users.v1.UpdateUserUseCase.Abstraction
{
    public interface IOutputPort
    {
        void UserNotFound();
        void InvalidRequest();
        void UserUpdated();
    }
}