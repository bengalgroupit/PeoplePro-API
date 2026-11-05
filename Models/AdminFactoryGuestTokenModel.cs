 
namespace PeoplePro.Models;

public class AdminFactoryGuestTokenModel
{
    public long TokenId { get; set; }

    public string TokenNo { get; set; }

    public string RequestedAt { get; set; }

    public string? FactoryGuestId { get; set; }
}