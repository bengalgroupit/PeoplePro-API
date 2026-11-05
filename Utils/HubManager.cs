 
using Microsoft.Extensions.Caching.Memory;
using PeoplePro.DbContext;
using PeoplePro.ViewModels;

namespace PeoplePro.Utils;

public class HubManager : IHubManager
{
    private readonly IMemoryCache _cache;
    private const string HubCacheKey = "HubCacheKey";
    private const string VehicleCacheKey = "VehicleCacheKey";
    private readonly Hive _hive;
    private readonly ILogger<HubManager> _logger;

    public HubManager(
        IMemoryCache memoryCache,
        IConfiguration configuration,
        ILogger<HubManager> logger)
    {
        _logger = logger;
        try
        {
            _hive = new Hive(configuration);
            List<HubUserViewModel> hubUsers = _hive.GetHubUsers();
            foreach (var user in hubUsers.Where<HubUserViewModel>((Func<HubUserViewModel, bool>) (user => user.IsConnected)))
            {
                user.IsConnected = false;
                _hive.UpdateHubUser(user);
            }
            _cache = memoryCache;
            _cache.Set<List<HubUserViewModel>>(nameof (HubCacheKey), hubUsers);
            _cache.Set<Dictionary<string, List<string>>>(nameof (VehicleCacheKey), new Dictionary<string, List<string>>());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public void Join(string vehicleId, string connectionId)
    {
        Dictionary<string, List<string>> dictionary = _cache.Get<Dictionary<string, List<string>>>("VehicleCacheKey");
        dictionary[vehicleId].Add(connectionId);
        _cache.Set<Dictionary<string, List<string>>>("VehicleCacheKey", dictionary);
    }

    public void Leave(string vehicleId, string connectionId)
    {
        Dictionary<string, List<string>> dictionary = _cache.Get<Dictionary<string, List<string>>>("VehicleCacheKey");
        dictionary[vehicleId].Remove(connectionId);
        _cache.Set<Dictionary<string, List<string>>>("VehicleCacheKey", dictionary);
    }

    public List<HubUserViewModel> GetUsersExcept(string empCode)
    {
        try
        {
            return _cache.Get<List<HubUserViewModel>>("HubCacheKey").Where<HubUserViewModel>((Func<HubUserViewModel, bool>) (u => u.EmpCode != empCode)).ToList<HubUserViewModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + " (GetUsersExcept) " + empCode);
            return new List<HubUserViewModel>();
        }
    }

    public HubUserViewModel Disconnected(string connectionId)
    {
        try
        {
            List<HubUserViewModel> source = _cache.Get<List<HubUserViewModel>>("HubCacheKey");
            var user = source.FirstOrDefault<HubUserViewModel>((Func<HubUserViewModel, bool>) (u => u.ConnectionId == connectionId));
            if (user == null)
                return new HubUserViewModel();
            user.IsConnected = false;
            user.LastSeen = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            user.ConnectionId = string.Empty;
            _cache.Set<List<HubUserViewModel>>("HubCacheKey", source);
            _hive.UpdateHubUser(user);
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + " (Disconnected) ");
            return new HubUserViewModel();
        }
    }

    public void Subscribe(HubUserViewModel user, string connectionId)
    {
        try
        {
            List<HubUserViewModel> source = _cache.Get<List<HubUserViewModel>>("HubCacheKey");
            var hubUserViewModel = source.FirstOrDefault<HubUserViewModel>((Func<HubUserViewModel, bool>) (u => u.EmpCode == user.EmpCode));
            if (hubUserViewModel != null)
                source.Remove(hubUserViewModel);
            user.IsConnected = true;
            user.LastSeen = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            user.ConnectionId = connectionId;
            source.Add(user);
            _hive.UpdateHubUser(user);
            _cache.Set<List<HubUserViewModel>>("HubCacheKey", source);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + " (Subscribe) ");
        }
    }
}