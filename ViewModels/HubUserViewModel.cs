

namespace PeoplePro.ViewModels;

public class HubUserViewModel
{
    public string? EmpCode { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? Department { get; set; }

    public string? ConnectionId { get; set; }

    public byte[] Photo { get; set; }

    public string? LastSeen { get; set; }

    public bool IsConnected { get; set; }
}