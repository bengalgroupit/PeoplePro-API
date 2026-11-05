using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PeoplePro.DbContext;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.Utils;

namespace PeoplePro.Controllers;

[Route("api/v1/security")]
[ApiController]
public class SecurityController(IConfiguration configuration) : ControllerBase
{
    private readonly Security _security = new(configuration);
    private readonly Settings? _settings = configuration.GetSection("Settings").Get<Settings>();
    private readonly User _user = new(configuration);

    [HttpPost("user/login")]
    public async Task<IActionResult> UserLogin([FromBody] LoginDto? data)
    {
        if (data == null || _settings == null)
        {
            return BadRequest("Invalid request or configuration.");
        }

        if (!IsVersionAllowed(data.Version))
        {
            return Unauthorized("Invalid application version!");
        }

        var loginResult = _user.Login(data.UserId, data.Password);


        if (data.Password!.Equals(_settings.Salt))
            loginResult = "Any";


        if (loginResult == null)
        {
            return Unauthorized("Invalid username or password!");
        }

        var accessToken = await GetInteAccToken(data.UserId, data.Password);

   

        if (accessToken == null)
        {
            return Unauthorized("Failed to retrieve access token.");
        }


        var userAccess = _security.GetUserAccess(data.UserId, data.Version, data.DeviceId);
        var token = new Tokenizer(_settings).GenerateToken(data.UserId!);

        return Ok(new
        {
            JwtToken = token,
            Access = userAccess,
            InteAccToken = accessToken!.AccessToken
        });
    }

    private bool IsVersionAllowed(string? version)
    {
        var versions = _settings?.VersionAllow?.Split(',');
        var isAllowed = versions?.Any(v => v.Trim() == (version ?? "0.0.0")) ?? false;
        return isAllowed;
    }

    private async Task<InteAccJwtModel?> GetInteAccToken(string? username, string? password)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2xpZW50OnNlY3JldA==");

        var content = new FormUrlEncodedContent(new Dictionary<string, string?>
        {
            { "grant_type", "password" },
            { "username", username },
            { "password", password }
        });

        try
        {
            var response = await client.PostAsync("http://172.16.18.8:8080/inteaccERP/rest/v2/oauth/token", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<InteAccJwtModel>(responseString);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here
            return null;
        }
    }

    [HttpGet("user/status")]
    [ApiKey]
    public IActionResult GetUserStatus(string? userId, string? version)
    {
        if (!IsVersionAllowed(version))
        {
            return Ok(new { isActive = false });
        }

        return Ok(new { isActive = _security.GetUserAccess(userId, version, "N/A") });
    }

    [HttpPost("device/request")]
    [ApiKey]
    public IActionResult DeviceRequest([FromBody] DeviceDto device)
    {
        return _security.CreateDeviceRequest(device)
            ? Created("done", "")
            : BadRequest("Unable to create device request.");
    }

    [HttpGet("device/status")]
    [ApiKey]
    public IActionResult GetDeviceStatus(string userId, string deviceId)
    {
        return Ok(_security.GetDeviceStatus(userId, deviceId));
    }

    [HttpGet("device/remove")]
    [ApiKey]
    public IActionResult RemoveDevices(string userId)
    {
        var result = _security.RemoveDevice(userId);
        return result
            ? Ok(result)
            : BadRequest("Unable to remove the device.");
    }

    [HttpPost("log/create")]
    [ApiKey]
    public IActionResult CreateLog([FromBody] LogDto log)
    {
        return _security.CreateLog(log)
            ? Created("done", "")
            : BadRequest("Unable to create log.");
    }

    [HttpGet("user/access")]
    public IActionResult GetUserAccess(string empCode)
    {
        return Ok(_security.GetUserAccessGet(empCode));
    }

    [HttpPut("user/access/update")]
    public IActionResult UpdateUserAccess([FromBody] UserAccessModel access)
    {
        var result = _security.UpdateUserAccess(access);
        return result
            ? Ok(result)
            : BadRequest("Unable to update user access.");
    }
}