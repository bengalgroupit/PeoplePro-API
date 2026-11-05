
namespace PeoplePro.ViewModels;

public class MealOffPendingListViewModel
{
    public long MealOffId { get; set; }

    public string? EmpCode { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int Days { get; set; }

    public DateTime SubmittedAt { get; set; }

    public string? Remarks { get; set; }
}