
using PeoplePro.Models;

namespace PeoplePro.ViewModels;

public class UserDataViewModel
{
    public UserInformationViewModel UserInformation { get; set; } = new();

    public List<UserAttendanceZoneModel> AttendanceZones { get; set; } = new();

    public List<NoticeModel> Notices { get; set; } = new();

    public List<PolicyModel> Policies { get; set; } = new();

    public string? ServerToday { get; set; }

    public long LastNotificationId { get; set; }

    public AttendanceBaseLatLng AttendanceBaseLatLng { get; set; } = new(0.0, 0.0);

    public PopupNotification PopNotification { get; set; } = new();

    public AgeModel Birthday { get; set; } = new();

    public DurationModel ServiceDuration { get; set; } = new();

    public List<HolidayModel> Holidays { get; set; }
    public int ApprovalPendingCount { get; set; }
}