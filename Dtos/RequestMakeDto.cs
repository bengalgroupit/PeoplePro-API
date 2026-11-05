
namespace PeoplePro.Dtos;

public class RequestMakeDto
{
    public string? EmpCode { get; set; }

    public int RequestTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Remarks { get; set; }

    public int MealCount { get; set; }
}