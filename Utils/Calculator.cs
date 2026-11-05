using PeoplePro.Models;

namespace PeoplePro.Utils;

public class Calculator
{
    public static AgeModel CalculateAge(DateTime dateOfBirth)
    {
        return CalculateDifference(dateOfBirth, DateTime.Today, isAgeCalculation: true);
    }

    public static DurationModel CalculateDuration(DateTime joiningDate)
    {
        return CalculateDifference(joiningDate, DateTime.Today, isAgeCalculation: false);
    }

    private static dynamic CalculateDifference(DateTime startDate, DateTime endDate, bool isAgeCalculation)
    {
        var years = endDate.Year - startDate.Year;
        var months = endDate.Month - startDate.Month;
        var days = endDate.Day - startDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(endDate.Year, (endDate.Month == 1) ? 12 : endDate.Month - 1);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        var isExactAnniversary = (startDate.Month == endDate.Month && startDate.Day == endDate.Day);

        if (isAgeCalculation)
        {
            return new AgeModel()
            {
                Year = years,
                Month = months,
                Day = days,
                IsBirthdayToday = isExactAnniversary
            };
        }
        else
        {
            return new DurationModel()
            {
                Year = years,
                Month = months,
                Day = days,
                IsOneYearToday = isExactAnniversary
            };
        }
    }
}