

namespace PeoplePro.Models;

public class MemberModel
{
    public string EmpCode { get; set; }

    public string Name { get; set; }

    public string Designation { get; set; }

    public string Department { get; set; }

    public string Company { get; set; }

    public string Unit { get; set; }

    public bool IsRiceService { get; set; }

    public bool IsFreeService { get; set; }

    public bool IsActive { get; set; }

    public string CardId { get; set; }

    public bool IsGuest { get; set; }

    public bool IsMasterCard { get; set; }
}