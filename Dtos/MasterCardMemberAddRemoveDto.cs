
using System.ComponentModel;

namespace PeoplePro.Dtos;

public class MasterCardMemberAddRemoveDto
{
    [DefaultValue("047785")]
    public string EmpId { get; set; }

    [DefaultValue("999999")]
    public string CardId { get; set; }
}