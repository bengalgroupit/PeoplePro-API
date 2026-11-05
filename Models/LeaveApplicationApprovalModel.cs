

namespace PeoplePro.Models;

public class LeaveApplicationApprovalModel
{
    public int StepNumber { get; set; }

    public string? TaskName { get; set; }

    public string? Approver { get; set; }

    public string? ActionDate { get; set; }

    public string? Status { get; set; }
}