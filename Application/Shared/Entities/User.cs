using Application.Shared.Models.Request;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Application.UseCases.Users.v1.UpdateUserUseCase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public long CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public Adress Adress { get; set; } = null!;
        public Login Login { get; set; } = null!;

        public ICollection<Image> Images { get; set; } = new List<Image>();
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
