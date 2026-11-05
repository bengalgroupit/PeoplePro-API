
namespace PeoplePro.Models;

public class HolidayModel
{
    public long HolidayId { get; set; }

    public string? Event { get; set; }

    public string? Date { get; set; }

    public string? Day { get; set; }

    public DateTime EventDate { get; set; }

    public bool IsUpcoming { get; set; }

    public int DayCount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}