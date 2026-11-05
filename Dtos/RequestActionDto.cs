
namespace PeoplePro.Dtos;

public class RequestActionDto
{
    public long RequestLineId { get; set; }

    public int StatusId { get; set; }

    public string? ActionBy { get; set; }
}