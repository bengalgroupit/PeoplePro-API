
namespace PeoplePro.Models;

public class RequestPendingLineModel
{
    public long RequestLineId { get; set; }

    public string? RequestTypeName { get; set; }

    public string? EmpCode { get; set; }

    public string? Designation { get; set; }

    public string? Department { get; set; }

    public string? Location { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MealCount { get; set; }

    public DateTime SubmittedAt { get; set; }

    public string? Remarks { get; set; }

    public string? EmpName { get; set; }
}