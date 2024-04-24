﻿namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;

public class AddressRequest
{
    public string? Street { get; set; }
    public string? Neighborhood { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string? Complement { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string? Number { get; set; }
}