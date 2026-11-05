using System.ComponentModel;

namespace PeoplePro.Dtos;

public class MemberActiveInactiveDto
{
    [DefaultValue("047785")]
    public string EmpId { get; set; }

    [DefaultValue("1")]
    public string UserId { get; set; }
}