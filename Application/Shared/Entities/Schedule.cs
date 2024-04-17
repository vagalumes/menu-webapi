using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Shared.Entities
{
    public class Schedule()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public Information Information { get; set; } = null!;

        public Schedule(DayOfWeek dayOfWeek, TimeOnly start, TimeOnly end) : this()
        {
            DayOfWeek = dayOfWeek;
            Start = start;
            End = end;
        }
    }
}