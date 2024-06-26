﻿using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;

public class CreateRestaurantInformationRequestValidator : AbstractValidator<InformationRequest>
{
    public CreateRestaurantInformationRequestValidator()
    {
        RuleFor(i => i.Schedules)
            .NotEmpty()
            .WithMessage("É obrigatório definir um horário de funcionamento.");

        RuleForEach(s => s.Schedules).SetValidator(new CreateRestaurantScheduleValidator());
    }
}