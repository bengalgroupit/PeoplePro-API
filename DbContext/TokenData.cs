

namespace PeoplePro.DbContext;

public class TokenData
{
    public long TokenNo { get; set; }

    public int MealCount { get; set; }

    public string Name { get; set; }

    public string Designation { get; set; }

    public string Department { get; set; }

    public string Message { get; set; }

    public int MealTotal { get; set; }

    public string EmpIds { get; set; }

    public bool IsRegistered { get; set; }

    public bool IsGuestMeal { get; set; }
}