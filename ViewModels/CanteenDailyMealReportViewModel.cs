namespace PeoplePro.ViewModels;

public class CanteenDailyMealReportViewModel
{
    public DateTime IssueDate { get; set; }
    public string EmpId { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public string Unit { get; set; }
    public int EmpMeal { get; set; }
    public int GuestMeal { get; set; }
    public bool IsEmpTaken { get; set; }
    public string DriverId { get; set; }
    public int DriverMeal { get; set; }
    public bool IsDriverTaken { get; set; }
    public int TotalMeal { get; set; }
    public bool IsMealClosed { get; set; }
    public string StatusText { get; set; }

    public bool IsFreeService { get; set; }
    public bool IsRiceService { get; set; }
}