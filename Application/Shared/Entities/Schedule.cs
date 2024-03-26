using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Shared.Entities
{
    public class Schedule(DayOfWeek dayOfWeek, TimeOnly start, TimeOnly end)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; } = dayOfWeek;
        public TimeOnly Start { get; set; } = start;
        public TimeOnly End { get; set; } = end;
        public Information Information { get; set; } = null!;
    }
}
