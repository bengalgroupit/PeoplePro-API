using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeoplePro.DbContext;
using PeoplePro.Reports;
using PeoplePro.ViewModels;

namespace PeoplePro.Controllers;

[Route("api/v1/report")]
[ApiController]
public class ReportController(IConfiguration configuration) : ControllerBase
{
    private readonly Report _report = new(configuration);

    [HttpGet("regularization")]
    public IActionResult GetAttendanceRegularization(string empCode, string lines)
    {
        var regularizationModelList = JsonConvert.DeserializeObject<List<AttendanceRegularizationModel>>(lines);
        var regularizationReport = new RegularizationReport();
        var memoryStream = new MemoryStream();
        var attendances = _report.GetAttendances(empCode);
        attendances.RegularizationLines = regularizationModelList;
        regularizationReport.DataSource = attendances;
        regularizationReport.ExportToPdf(memoryStream);
        return File(memoryStream.ToArray(), "application/pdf", "attendance-regularization-" + empCode + ".pdf");
    }

    [HttpGet("job-card")]
    public IActionResult GetAttendanceCard(
        string empCode,
        string fromDate,
        string toDate)
    {
        var jobCardReport = new JobCardReport();
        var memoryStream = new MemoryStream();
        var attendances = _report.GetAttendances(empCode, fromDate, toDate);
        CalculateReportSummary(attendances);
        jobCardReport.DataSource = attendances;
        jobCardReport.ExportToPdf(memoryStream);
        return File(memoryStream.ToArray(), "application/pdf", "job-card-" + empCode + ".pdf");
    }

    private static void CalculateReportSummary(AttendanceReportModel data)
    {
        data.TotalDays = data.AttendanceLines.Count;
        data.Present = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x =>
        {
            if (x.Status == null)
                return false;
            return x.Status.Equals("P") || x.Status.Equals("LI") || x.Status.Equals("PN") || x.Status.Equals("WP") || x.Status.Equals("HP") || x.Status.Equals("EO") || x.Status.Equals("OS") || x.Status.Equals("WPN") || x.Status.Equals("HPN") || x.Status.Equals("LIEO");
        }));
        data.Leave = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x => x.Status == "LV"));
        data.Late = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x => x.Status == "LI"));
        data.Absent = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x => x.Status == "A"));
        data.Weekend = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x => x.Status == "W"));
        data.Holidays = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x => x.Status == "H"));
        data.HwPresent = data.AttendanceLines.Count<AttendanceLineModel>((Func<AttendanceLineModel, bool>) (x =>
        {
            if (x.Status == null)
                return false;
            return x.Status.Equals("HP") || x.Status.Equals("WP") || x.Status.Equals("WPN") || x.Status.Equals("HPN");
        }));
        data.OvertimeHr = data.AttendanceLines.Sum<AttendanceLineModel>((Func<AttendanceLineModel, decimal>) (x => x.OverTimeHours));
    }
}