

namespace PeoplePro.Models;

public class UserAccessModel
{
    public string? UserId { get; set; }

    public int EditionId { get; set; }

    public string? Edition { get; set; }

    public bool IsActive { get; set; }

    public bool ControlPanel { get; set; }

    public bool Notifier { get; set; }

    public bool ZoneManager { get; set; }

    public bool LocationManager { get; set; }

    public bool AttendanceMonitor { get; set; }

    public bool Poll { get; set; }

    public bool Directory { get; set; }

    public bool Canteen { get; set; }

    public bool Transport { get; set; }

    public bool Notification { get; set; }

    public bool Notice { get; set; }

    public bool Attendance { get; set; }

    public bool Leave { get; set; }

    public bool Outstation { get; set; }

    public bool Approval { get; set; }

    public bool Payslip { get; set; }

    public bool JobCard { get; set; }

    public bool Holiday { get; set; }

    public bool JobHistory { get; set; }

    public bool Hiring { get; set; }

    public bool ProvidentFund { get; set; }

    public bool MyProfile { get; set; }

    public bool Policies { get; set; }

    public bool UpdateProfile { get; set; }

    public bool CanteenManager { get; set; }

    public bool JobCardDownload { get; set; }

    public bool Regularization { get; set; }

    public bool BusLate { get; set; }

    public int Timeout { get; set; }

    public string? DeviceId { get; set; }

    public bool PrintToken { get; set; }

    public string? DriverId { get; set; }

    public bool Debug { get; set; }
}