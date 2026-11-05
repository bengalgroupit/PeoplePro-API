
using Microsoft.AspNetCore.Mvc;
using PeoplePro.DbContext;
using PeoplePro.Dtos;

namespace PeoplePro.Controllers;

[Route("api/v1/canteen")]
[ApiController]
public class CanteenController(IConfiguration configuration) : ControllerBase
{

    private readonly Security _security = new(configuration);

    private readonly BGICMS _dbBGICMS = new(configuration);

    [HttpPost("token")]
    public IActionResult TokenRequest([FromBody] TokenDto token)
    {
        var isDeviceAuthorized = _security.ValidateDevice(token.UserId, token.DeviceId);
        if (!isDeviceAuthorized)
            return BadRequest("Device not authorized!");
        return _dbBGICMS.TokenRequest(token.UserId) ? Ok("Token request successful.") : BadRequest("Unable to process your token request.");
    }

    [HttpPost("meal/closing")]
    public IActionResult MealClosing([FromBody] MealClosingDto data)
    {

        return Ok(_dbBGICMS.MealClosing(data));
    }

    [HttpGet("meal/closing/list")]
    public IActionResult MealClosingList(string username) => Ok(_dbBGICMS.MealClosingList(username));

    [HttpPut("meal/closing/cancel")]
    public IActionResult MealClosingCancel([FromBody] MealClosingCancelDto data)
    {
        return !_dbBGICMS.MealClosingCancel(data)
              ? BadRequest("Unable to process your meal cancellation request.")
              : Ok("Meal closing cancelled successfully.");

    }

    [HttpGet("meal/card")]
    public IActionResult GetMealCard(string username, string startDate, string endDate) => Ok(_dbBGICMS.GetMealCard(username, startDate, endDate));


}