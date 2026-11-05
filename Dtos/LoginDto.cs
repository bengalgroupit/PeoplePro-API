
using System.ComponentModel;

namespace PeoplePro.Dtos;

public class LoginDto
{
    [DefaultValue("008766")]
    public string? UserId { get; set; }

    [DefaultValue("008766")]
    public string? Password { get; set; }

    [DefaultValue("3.3.7")]
    public string? Version { get; set; }

    [DefaultValue("UNKNOWN")]
    public string? DeviceId { get; set; }
}