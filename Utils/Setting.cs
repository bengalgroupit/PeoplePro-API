 

namespace PeoplePro.Utils;

public class Settings
{
    public string ApiKey { get; set; } = string.Empty;
    public string SigningKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;

    public string VersionAllow { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
}