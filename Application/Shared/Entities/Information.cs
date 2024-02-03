using Application.Shared.Models.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.Shared.Entities
{
    public class Information
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public Guid RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; } = null!;

        public Information() { }

        public Information(InformationRequest request) => Description = request.Description;

        public Information(InformationRequest? request, Information? inform) => Description = request!.Description ?? inform!.Description;

        public void Update(InformationRequest request) => Description = request.Description ?? Description;
    }
}
