
namespace PeoplePro.Models;

public class MealMonthlySummaryModel
{
    public string Title { get; set; } = string.Empty;

    public int Total { get; set; }

    public int Employee { get; set; }

    public int Guest { get; set; }

    public int Driver { get; set; }
}