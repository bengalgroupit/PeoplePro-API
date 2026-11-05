
namespace PeoplePro.Models;

public class PollLineModel
{
    public long PollLineId { get; set; }

    public string? Name { get; set; }

    public int PollLineCount { get; set; }

    public decimal PollPercent { get; set; }
}