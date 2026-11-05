
namespace PeoplePro.Models;

public class MealCardModel
{
    public DateTime MealDate { get; set; }

    public int MealCount { get; set; }

    public int GuestCount { get; set; }

    public bool IsMealClosed { get; set; }

    public string StatusText { get; set; }
}