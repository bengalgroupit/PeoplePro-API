using System.ComponentModel;

namespace PeoplePro.Dtos;

public class MealClosingDto
{
    [DefaultValue("088827")]
    public string Username { get; set; }

    public DateTime IssueDate { get; set; }
}