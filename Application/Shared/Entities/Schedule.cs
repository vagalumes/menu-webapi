using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities;

public class Schedule()
{
    public Schedule(DayOfWeek dayOfWeek, TimeOnly start, TimeOnly end) : this()
    {
        DayOfWeek = dayOfWeek;
        Start = start;
        End = end;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public Information Information { get; set; } = null!;
}