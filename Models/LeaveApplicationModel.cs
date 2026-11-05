
namespace PeoplePro.Models;

public class LeaveApplicationModel
{
    public string? ApplicationDate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double TotalDays { get; set; }

    public string? Remarks { get; set; }

    public string? Status { get; set; }

    public string? LeaveType { get; set; }

    public string? DurationType { get; set; }

    public string? DocNumber { get; set; }
}