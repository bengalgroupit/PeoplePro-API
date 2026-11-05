
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PeoplePro.Utils;

public class TrackerHub : Hub
{
    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    private static readonly Dictionary<string, TrackerUserModel> TrackerUsers = new Dictionary<string, TrackerUserModel>();

    public override Task OnConnectedAsync()
    {
        var query = Context.GetHttpContext().Request.Query;
        var empCode = query["empCode"].FirstOrDefault<string>() ?? "";
        var str1 = query["name"].FirstOrDefault<string>() ?? "";
        var str2 = query["designation"].FirstOrDefault<string>() ?? "";
        var str3 = query["department"].FirstOrDefault<string>() ?? "";
        var boolean = Convert.ToBoolean(query["isTracker"].FirstOrDefault<string>() ?? "false");
        string str4;
        if (TrackerUsers.ContainsKey(empCode))
        {
            KeyValuePair<string, TrackerUserModel> keyValuePair = TrackerUsers.First<KeyValuePair<string, TrackerUserModel>>((Func<KeyValuePair<string, TrackerUserModel>, bool>) (u => u.Key.Equals(empCode)));
            keyValuePair.Value.ActivityTime = new DateTime?(DateTime.Now);
            keyValuePair.Value.ConnectionId = Context.ConnectionId;
            str4 = JsonConvert.SerializeObject(keyValuePair.Value, _settings);
        }
        else
        {
            var trackerUserModel = new TrackerUserModel()
            {
                Username = empCode,
                Name = str1,
                Designation = str2,
                Department = str3,
                ActivityTime = new DateTime?(DateTime.Now),
                IsTracker = boolean,
                ConnectionId = Context.ConnectionId
            };
            TrackerUsers.Add(empCode, trackerUserModel);
            str4 = JsonConvert.SerializeObject(trackerUserModel, _settings);
        }
        Clients.Caller.SendAsync("onConnected", Context.ConnectionId);
        Clients.All.SendAsync("onUserConnected", str4);
        if (boolean)
            Clients.All.SendAsync("onTrackerConnected", empCode);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        KeyValuePair<string, TrackerUserModel> keyValuePair = TrackerUsers.First<KeyValuePair<string, TrackerUserModel>>((Func<KeyValuePair<string, TrackerUserModel>, bool>) (u => u.Value.ConnectionId.Equals(Context.ConnectionId)));
        keyValuePair.Value.ActivityTime = new DateTime?(DateTime.Now);
        keyValuePair.Value.ConnectionId = null;
        var str = JsonConvert.SerializeObject(keyValuePair, _settings);
        Clients.Caller.SendAsync("onDisconnected", Context.ConnectionId);
        Clients.All.SendAsync("onUserDisconnected", str);
        if (keyValuePair.Value.IsTracker)
            Clients.All.SendAsync("onTrackerDisconnected", keyValuePair.Key);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("GetTrackerUsers")]
    public Task GetTrackerUsers()
    {
        Clients.Caller.SendAsync("onGetTrackerUsers", JsonConvert.SerializeObject(TrackerUsers.Select<KeyValuePair<string, TrackerUserModel>, TrackerUserModel>((Func<KeyValuePair<string, TrackerUserModel>, TrackerUserModel>) (u => u.Value)).ToList<TrackerUserModel>(), _settings));
        return Task.CompletedTask;
    }
}