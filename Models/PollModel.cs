
namespace PeoplePro.Models;

public class PollModel
{
    public long PollId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public long PollLineId { get; set; }

    public int PollTotal { get; set; }
}