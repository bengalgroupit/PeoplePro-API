
namespace PeoplePro.ViewModels;

public class AttendanceLineModel
{
    public DateTime Date { get; set; }

    public string? Day { get; set; }

    public string? Status { get; set; }

    public string? InTime { get; set; }

    public string? OutTime { get; set; }

    public int LateMinutes { get; set; }

    public decimal OverTimeHours { get; set; }

    public string? Remarks { get; set; }
}