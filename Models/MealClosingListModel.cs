
namespace PeoplePro.Models;

public class MealClosingListModel
{
    public long Id { get; set; }

    public string EmpId { get; set; }

    public DateTime IssueDate { get; set; }

    public bool IsDriver { get; set; }

    public bool Cancellable { get; set; }
}