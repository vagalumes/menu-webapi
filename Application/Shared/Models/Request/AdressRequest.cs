namespace Application.Shared.Models.Request
{
    public class AdressRequest
    {
        public string? Road { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? UF { get; set; }
        public string? Complement { get; set; }
        public long Cep { get; set; }
        public int Number { get; set; }
    }
}
