﻿using Microsoft.AspNetCore.Http;

namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions
{
    public interface ICreateImageUseCase
    {
        Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken);
        void SetOutputPort(IOutputPort outputPort);
    }
}