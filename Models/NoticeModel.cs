
namespace PeoplePro.Models;

public class NoticeModel
{
    public long NoticeId { get; set; }

    public string? Title { get; set; }

    public string? Image { get; set; }

    public string? Thumbnail { get; set; }

    public string? Content { get; set; }

    public DateTime PublishDate { get; set; }

    public bool IsActive { get; set; }
}