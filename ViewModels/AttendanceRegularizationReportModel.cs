
namespace PeoplePro.ViewModels;

public class AttendanceRegularizationReportModel
{
    public string EmpCode { get; set; } = string.Empty;

    public string? Name { get; set; } = string.Empty;

    public string? Department { get; set; } = string.Empty;

    public string? JobTitle { get; set; } = string.Empty;

    public string? Company { get; set; } = string.Empty;

    public string? OpLocation { get; set; } = string.Empty;

    public List<AttendanceRegularizationModel>? RegularizationLines { get; set; }
}