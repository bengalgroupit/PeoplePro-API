
using System.ComponentModel;

namespace PeoplePro.Dtos;

public class MealClosingCancelDto
{
    [DefaultValue("088827")]
    public string Username { get; set; }

    public DateTime MealDate { get; set; }
}