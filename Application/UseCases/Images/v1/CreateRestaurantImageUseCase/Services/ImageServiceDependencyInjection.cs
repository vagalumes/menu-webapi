﻿using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories;
using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Application.UseCases.Images.v1.UploadService.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services
{
    public static class ImageServiceDependencyInjection
    {
        public static IServiceCollection AddImageDependencies(this IServiceCollection services)
        {
            return services.AddScoped<IImageRepository, ImageRepository>()
                .AddScoped<IUploadService, UploadService.UploadService>();
        }
    }
}