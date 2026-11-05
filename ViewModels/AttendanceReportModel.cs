

namespace PeoplePro.ViewModels;

public class AttendanceReportModel
{
    public string Period { get; set; } = string.Empty;

    public string EmpCode { get; set; } = string.Empty;

    public string? Name { get; set; } = string.Empty;

    public string? Department { get; set; } = string.Empty;

    public string? Section { get; set; } = string.Empty;

    public string? JobTitle { get; set; } = string.Empty;

    public string? Company { get; set; } = string.Empty;

    public string? OpLocation { get; set; } = string.Empty;

    public int TotalDays { get; set; }

    public int Leave { get; set; }

    public int Present { get; set; }

    public int Late { get; set; }

    public int Absent { get; set; }

    public int Weekend { get; set; }

    public int HwPresent { get; set; }

    public int Holidays { get; set; }

    public decimal OvertimeHr { get; set; }

    public List<AttendanceLineModel>? AttendanceLines { get; set; }
}