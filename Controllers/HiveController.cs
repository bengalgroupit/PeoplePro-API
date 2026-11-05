
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PeoplePro.DbContext;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.Utils;
using PeoplePro.ViewModels;

namespace PeoplePro.Controllers;

[Route("api/v1/hive")]
[ApiController]
public class HiveController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly IWebHostEnvironment _environment;
    private readonly Hive _hive;
    private readonly User _user;
    private readonly Settings? _settings;
    private readonly CacheStore _cacheStore;

    public HiveController(
        IConfiguration configuration,
        IWebHostEnvironment environment,
        IMemoryCache memoryCache)
    {
        _environment = environment;
        _memoryCache = memoryCache;
        _hive = new Hive(configuration);
        _user = new User(configuration);
        _settings = configuration.GetSection("Settings").Get<Settings>();
        _cacheStore = new CacheStore(memoryCache, _hive, _user);
    }

    [HttpGet]
    public string Get() => "PeoplePro API is up and running!";

    [HttpPost("cache/clear")]
    public IActionResult ClearCache(string key, string empCode)
    {
        var flag = false;
        if (key != "policy")
        {
            if (key != "notice")
            {
                if (key != "notification")
                {
                    if (key == "user")
                        flag = _cacheStore.Clear(CacheKeyConst.CacheKeyUserInformation(empCode));
                }
                else
                {
                    flag = _cacheStore.Clear(CacheKeyConst.CacheKeyNotification);
                    if (flag)
                        flag = _cacheStore.Clear(CacheKeyConst.CacheKeyNotificationId);
                }
            }
            else
                flag = _cacheStore.Clear(CacheKeyConst.CacheKeyNotice);
        }
        else
            flag = _cacheStore.Clear(CacheKeyConst.CacheKeyPolicy);
        return flag ? Ok(true) : BadRequest(false);
    }

    [HttpGet("user/data")]
    public IActionResult GetUserData(string empCode)
    {
        var policies = _cacheStore.GetPolicies();
        var notices = _cacheStore.GetNotices();
        var holidays = _cacheStore.GetHolidays();
        var popupNotification = _cacheStore.GetPopupNotification();
        var lastNotificationId = _cacheStore.GetLastNotificationId();
        var str = DateTime.Today.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        var userInformation = _cacheStore.GetUserInformation(empCode);
        var userDataViewModel = new UserDataViewModel()
        {
            UserInformation = userInformation,
            Notices = notices,
            Policies = policies,
            Holidays = holidays
        };
        userDataViewModel.Birthday = Calculator.CalculateAge(userDataViewModel.UserInformation.BirthDate);
        userDataViewModel.ServiceDuration = Calculator.CalculateDuration(userDataViewModel.UserInformation.JoiningDate);
        userDataViewModel.LastNotificationId = lastNotificationId;
        userDataViewModel.PopNotification = popupNotification;
        userDataViewModel.ServerToday = str;
        userDataViewModel.ApprovalPendingCount = _user.GetPendingApprovals(empCode).Count;
        userDataViewModel.AttendanceZones = GetAttendanceZones(empCode, userInformation.AttendanceLocationId ?? "");
        var attendanceZoneModel = userDataViewModel.AttendanceZones.Count > 0 ? userDataViewModel.AttendanceZones.First<UserAttendanceZoneModel>() : new UserAttendanceZoneModel();
        userDataViewModel.AttendanceBaseLatLng = new AttendanceBaseLatLng(attendanceZoneModel.BaseLatitude, attendanceZoneModel.BaseLongitude);
        return Ok(userDataViewModel);
    }

    private List<UserAttendanceZoneModel> GetAttendanceZones(
        string empCode,
        string attendanceLocationId)
    {
        return _user.GetUserAttendanceZones(empCode, attendanceLocationId);
    }

    [HttpGet("user/jobcard")]
    public IActionResult GetJobCard(string empId, string fromDate, string toDate) => Ok(_user.GetJobCard(empId, fromDate, toDate));

    [HttpGet("user/payslips")]
    public IActionResult GetPayslips(string empId)
    {
        var key = "ck-payslip" + empId;
        if (!_memoryCache.TryGetValue<List<PaySlipModel>>(key, out var payslips))
        {
            payslips = _user.GetPayslips(empId);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1.0));
            _memoryCache.Set<List<PaySlipModel>>(key, payslips, options);
        }
        return Ok(payslips);
    }

    [HttpGet("user/pending/approvals")]
    public IActionResult GetPendingApprovals(string empCode) => Ok(_user.GetPendingApprovals(empCode));

    [HttpGet("user/pf")]
    public IActionResult GetProvidentFund(string empId)
    {
        var key = "ck-pf" + empId;
        if (!_memoryCache.TryGetValue<List<ProvidentFundModel>>(key, out var providentFund))
        {
            var fromDate = new DateTime(2022, 1, 1);
            var today = DateTime.Today;
            providentFund = _user.GetProvidentFund(empId, fromDate, today);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1.0));
            _memoryCache.Set<List<ProvidentFundModel>>(key, providentFund, options);
        }
        return Ok(providentFund);
    }

    [HttpGet("user/payslip/lines")]
    public IActionResult GetPayslipLine(string payrollId)
    {
        var key = "ck-payslip-Line" + payrollId;
        if (!_memoryCache.TryGetValue<List<PaySlipLineModel>>(key, out var payslipLines))
        {
            payslipLines = _user.GetPayslipLines(payrollId);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1.0));
            _memoryCache.Set<List<PaySlipLineModel>>(key, payslipLines, options);
        }
        return Ok(payslipLines);
    }

    [HttpGet("user/leave/applications")]
    public IActionResult GetLeaveApplications(string empId) => Ok(_user.GetLeaveApplications(empId));

    [HttpGet("user/leave/approvals")]
    public IActionResult GetLeaveApprovals(string empId, string docNumber) => Ok(_user.GetLeaveApprovals(empId, docNumber));

    [HttpGet("user/outstation/duties")]
    public IActionResult GetOutstationDuties(string empId) => Ok(_user.GetOutstationDuties(empId));

    [HttpGet("user/outstation/approvals")]
    public IActionResult GetOutstationApprovals(string empId, string docNumber)
    {
        var key = "ck-outstation-approval-" + docNumber + empId;
        if (!_memoryCache.TryGetValue<List<LeaveApplicationApprovalModel>>(key, out var leaveApprovals))
        {
            leaveApprovals = _user.GetLeaveApprovals(empId, docNumber);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1.0));
            _memoryCache.Set<List<LeaveApplicationApprovalModel>>(key, leaveApprovals, options);
        }
        return Ok(leaveApprovals);
    }

    [HttpPost("user/profile/update")]
    [ApiKey]
    public IActionResult UpdateProfile([FromBody] ProfileUpdateDto data) => _user.ProfileUpdate(data) ? Created("done", "") : BadRequest("Unable to update profile.");

    [HttpPost("user/password/change")]
    [ApiKey]
    public IActionResult CreateLog([FromBody] PasswordDto data) => _user.ChangePassword(data) ? Created("done", "") : BadRequest("Unable to change password.");

    [HttpGet("user/profile")]
    public IActionResult GetProfile(string empCode) => Ok(_user.GetProfile(empCode));

    [HttpGet("departments")]
    public IActionResult GetDepartments()
    {
        if (!_memoryCache.TryGetValue<List<DepartmentModel>>("ck-departments", out var departments))
        {
            departments = _hive.GetDepartments();
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(45.0));
            _memoryCache.Set<List<DepartmentModel>>("ck-departments", departments, options);
        }
        return Ok(departments);
    }

    [HttpGet("employee/attendances")]
    public IActionResult GetEmployeeAttendances(
        string departmentId,
        DateTime entryDate)
    {
        var key = "ck-attendance-" + departmentId + "-" + entryDate.ToShortDateString();
        if (!_memoryCache.TryGetValue<List<EmployeeAttendanceModel>>(key, out var employeeAttendances))
        {
            employeeAttendances = _hive.GetEmployeeAttendances(departmentId, entryDate);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1.0));
            _memoryCache.Set<List<EmployeeAttendanceModel>>(key, employeeAttendances, options);
        }
        return Ok(employeeAttendances);
    }

   

    [HttpGet("image")]
    public IActionResult GetNoticeImage(string name)
    {
        var physicalPath = _environment.ContentRootPath + "\\upload\\images\\" + name;
        var contentType = "image/" + Path.GetExtension(name);
        try
        {
            return PhysicalFile(physicalPath, contentType);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("poll")]
    public IActionResult GetPoll(string empCode) => Ok(_hive.GetPoll(empCode));

    [HttpPost("poll/submit")]
    public IActionResult SubmitPoll(string empCode, long pollLineId) => _hive.SubmitPoll(empCode, pollLineId) ? Created("done", "") : BadRequest("Unable to poll.");

    [HttpGet("hub/users")]
    public IActionResult GetHubUser() => Ok(_hive.GetHubUsers());

    [HttpPost("user/attendance/zone/save")]
    public IActionResult SaveAttendanceZone([FromBody] List<AttendanceLocationModel> zones) => _user.SaveAttendanceZone(zones) ? Created("done", "") : BadRequest("Unable to save zone.");

    [HttpGet("user/attendance/zones")]
    public IActionResult GetAttendanceZones(string attendanceLocationId) => Ok(_user.GetAttendanceZones(attendanceLocationId));

    [HttpGet("user/attendance/locations")]
    public IActionResult GetAttendanceLocations() => Ok(_user.GetAttendanceLocations());

    [HttpPut("user/attendance/location/update")]
    public IActionResult UpdateUserAttendanceLocation(
        string empCode,
        string attendanceLocationId)
    {
        return _user.UpdateAttendanceLocation(empCode, attendanceLocationId) ? Created("done", "") : BadRequest("Unable to update attendance location.");
    }

    [HttpGet("user/editions")]
    public IActionResult GetUserEdition() => Ok(_hive.GetEditions());



    [HttpGet("user/updated")]
    public IActionResult GetUserAppUpdated() => Ok(_hive.GetUserAppUpdated());

}