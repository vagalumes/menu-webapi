using Application.Shared.Models.Request;

namespace Application.UseCases.Users.v1.UpdateUserUseCase.Models
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }
        public AdressRequest Address { get; set; } = new AdressRequest();
        public LoginRequest Access { get; set; } = new LoginRequest();
        public DateTime BirthDate { get; set; }
    }
}
