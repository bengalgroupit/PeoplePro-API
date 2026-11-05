
namespace PeoplePro.ViewModels;

public class RequestReportViewModel
{
    public string? EmpCode { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public string? Location { get; set; }

    public int TotalMealOff { get; set; }

    public int TotalMyGuest { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}