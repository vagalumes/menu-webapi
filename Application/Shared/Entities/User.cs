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
        public long Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public Address Address { get; set; } = null!;
        public Login Login { get; set; } = null!;

        public ICollection<UsersImages> Images { get; set; } = [];

        public void Update(UpdateUserRequest request) => Name = request.Name ?? Name;
    }
}
