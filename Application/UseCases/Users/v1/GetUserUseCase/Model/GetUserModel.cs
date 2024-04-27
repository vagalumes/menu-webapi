using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.GetUserUseCase.Model;

public class GetUserModel(User user)
{
    public string Name { get; set; } = user.Name;
    public long Cpf { get; set; } = user.Cpf;
    public DateTime BirthDate { get; set; } = user.BirthDate;
    public string? Nationality { get; set; } = user.Nationality;
    public Address Address { get; set; } = user.Address;
}