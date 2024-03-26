using Application.Shared.Models.Request;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Models
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = null!;
        public long CPF { get; set; }
        public LoginRequest Access { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
