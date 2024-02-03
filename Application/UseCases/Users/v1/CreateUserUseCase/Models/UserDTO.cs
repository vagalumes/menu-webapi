using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long CPF { get; set; }
        public Adress Adress { get; set; }
        public DateTime BirthDate { get; set; }

        public UserDto(Shared.Entities.User user)
        {
            Name = user.Name;
            CPF = user.CPF;
            BirthDate = user.BirthDate;
            Adress = user.Adress;
        }
    }
}
