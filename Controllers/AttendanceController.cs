using Microsoft.AspNetCore.Mvc;
using PeoplePro.DbContext;
using PeoplePro.Dtos;

namespace PeoplePro.Controllers;

[Route("api/v1/attendance")]
[ApiController]
public class AttendanceController(IConfiguration configuration) : ControllerBase
{
    private readonly Attendance _attendance = new(configuration);

    [HttpPost("take")]
    public IActionResult TakeAttendance([FromBody] AttendanceDto data)
    {
        var attendTime = _attendance.Take(data.EmpCode);
        if (!attendTime.HasValue)
            return BadRequest("Unable to take attendance!");
        _attendance.Log(data, attendTime);

        var attendanceTime = attendTime.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        return Ok(attendanceTime);
    }
}