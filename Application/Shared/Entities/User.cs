using Application.Shared.Models.Request;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Application.UseCases.Users.v1.UpdateUserUsecase.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class User : IdentityUser<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
