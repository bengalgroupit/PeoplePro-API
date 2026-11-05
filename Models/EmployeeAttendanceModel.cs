

namespace PeoplePro.Models;

public class EmployeeAttendanceModel
{
    public string? EmpCode { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? Section { get; set; }

    public string? Department { get; set; }

    public string? Location { get; set; }

    public string? Company { get; set; }

    public string? EntryTime { get; set; }

    public string? WorkShirtStart { get; set; }

    public int GraceMinute { get; set; }

    public string? AttendSource { get; set; }

    public bool IsPresent { get; set; }

    public bool IsLate { get; set; }

    public int LateMinute { get; set; }
}