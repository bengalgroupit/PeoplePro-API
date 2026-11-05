
using PeoplePro.Models;

namespace PeoplePro.ViewModels;

public class PayloadViewModel
{
    public bool IsAllowed { get; set; }

    public string? ServerToday { get; set; }

    public long LastNotificationId { get; set; }

    public List<ZoneModel>? Zones { get; set; }

    public List<NoticeModel>? Notices { get; set; }
}