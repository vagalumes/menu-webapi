using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Models;

public class UserDto(User user)
{
    public Guid Id { get; set; } = user.Id;
    public string Name { get; set; } = user.Name;
    public long Cpf { get; set; } = user.Cpf;
    public Address Address { get; set; } = user.Address;
    public DateTime BirthDate { get; set; } = user.BirthDate;
}