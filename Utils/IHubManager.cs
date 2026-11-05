 
using PeoplePro.ViewModels;

namespace PeoplePro.Utils;

public interface IHubManager
{
    HubUserViewModel Disconnected(string contextConnectionId);

    void Subscribe(HubUserViewModel user, string connectionId);

    List<HubUserViewModel> GetUsersExcept(string empCode);

    void Join(string vehicleId, string connectionId);

    void Leave(string vehicleId, string connectionId);
}