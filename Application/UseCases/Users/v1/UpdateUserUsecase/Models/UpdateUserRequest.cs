using Application.Shared.Models.Request;

namespace Application.UseCases.Users.v1.UpdateUserUsecase.Models
{
    public class UpdateUserRequest
    {
        public string Name { get; set; } = null!;
        public long CPF { get; set; }
        public AdressRequest Adress { get; set; } = null!;
        public LoginRequest Access { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
