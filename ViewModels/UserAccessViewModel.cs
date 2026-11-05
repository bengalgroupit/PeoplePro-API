
using PeoplePro.Models;

namespace PeoplePro.ViewModels;

public class UserAccessViewModel : UserAccessModel
{
    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }
}