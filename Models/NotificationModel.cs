
namespace PeoplePro.Models;

public class NotificationModel
{
    public long NotificationId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }
}