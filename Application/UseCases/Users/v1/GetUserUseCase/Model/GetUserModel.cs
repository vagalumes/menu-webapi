using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.GetUserUseCase.Model
{
    public class GetUserModel
    {
        public string Name { get; set; }
        public long CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public Adress Adress { get; set; }

        public GetUserModel(User user)
        {
            Name = user.Name;
            CPF = user.CPF;
            BirthDate = user.BirthDate;
            Nationality = user.Nationality;
            Adress = user.Adress;
        }
    }
}
