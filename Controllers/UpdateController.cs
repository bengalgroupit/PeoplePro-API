using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace PeoplePro.Controllers;

[Route("api/v1/update")]
[ApiController]
public class UpdateController(IConfiguration configuration, IWebHostEnvironment environment)
    : ControllerBase
{
    [HttpGet("check")]
    public IActionResult Check()
    {
        var section = configuration.GetSection("Update");
        var dictionary = new Dictionary<string, object?>();
        foreach (var configurationSection in section.GetChildren().Reverse<IConfigurationSection>())
            dictionary.Add(JsonNamingPolicy.CamelCase.ConvertName(configurationSection.Key), configurationSection.Value);
        return Ok(dictionary);
    }

    [HttpGet("apk")]
    public IActionResult GetApk(string version, string arch)
    {
        try
        {
            // Construct the APK filename
            var fileName = $"peoplepro.v{version}-{arch}-release.apk";

            // Combine paths using Path.Combine for cross-platform safety
            var path = Path.Combine(environment.ContentRootPath, "updates", "apk", fileName);

            // Check if the file exists before attempting to serve it
            if (!System.IO.File.Exists(path))
            {
                return NotFound($"File not found: {fileName}");
            }

            // Serve the file
            var fileStream = System.IO.File.OpenRead(path);
            return File(fileStream, "application/vnd.android.package-archive", fileName);
        }
        catch (Exception ex)
        {
            // Log the exception if necessary
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }


}