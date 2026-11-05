
namespace PeoplePro.Models;

public class RequestLineModel
{
    public long RequestLineId { get; set; }

    public string? EmpCode { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MealCount { get; set; }

    public DateTime SubmittedAt { get; set; }

    public string? Remarks { get; set; }

    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public int RequestTypeId { get; set; }

    public string? RequestTypeName { get; set; }

    public DateTime ActionAt { get; set; }
}