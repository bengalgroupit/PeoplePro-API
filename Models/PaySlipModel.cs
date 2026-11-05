

namespace PeoplePro.Models;

public class PaySlipModel
{
    public string? PayrollId { get; set; }

    public string? Name { get; set; }

    public string? FromDate { get; set; }

    public string? ToDate { get; set; }

    public double GrossAmount { get; set; }

    public double DeductionAmount { get; set; }

    public double NetAmount { get; set; }

    public string? InWord { get; set; }

    public string? SalaryType { get; set; }
}