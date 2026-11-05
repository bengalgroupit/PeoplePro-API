
namespace PeoplePro.Models;

public class OutstationModel
{
    public string? ApplicationDate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double TotalDays { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public string? DurationType { get; set; }

    public string? DocNumber { get; set; }
}