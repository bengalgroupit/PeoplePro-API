 
namespace PeoplePro.Models;

public class AdminMealClosingCountModel
{
    public DateTime IssueDate { get; set; }

    public bool IsToday { get; set; }

    public int Total { get; set; }
}