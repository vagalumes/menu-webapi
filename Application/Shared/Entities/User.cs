using Application.Shared.Models.Request;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Application.UseCases.Users.v1.UpdateUserUseCase.Models;

namespace Application.Shared.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public long CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public Adress Adress { get; set; } = null!;
        public Login Login { get; set; } = null!;

        public User() { }

        public User(CreateUserRequest request, AdressRequest adressRequest, LoginRequest loginRequest)
        {
            Name = request.Name;
            CPF = request.CPF;
            BirthDate = request.BirthDate;
            Adress = new Adress(adressRequest);
            Login = new Login(loginRequest);
        }

        public void Update(UpdateUserRequest request) => Name = request.Name ?? Name;
    }
}
