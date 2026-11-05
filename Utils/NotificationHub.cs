 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PeoplePro.ViewModels;

namespace PeoplePro.Utils;

[Authorize]
public class NotificationHub(IHubManager hubManager, ILogger<NotificationHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        try
        {
            Clients.Caller.SendAsync("onConnected", Context.ConnectionId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while connecting to the hub.");
        }
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Clients.Caller.SendAsync("onDisconnected", Context.ConnectionId);
        var hubUserViewModel = hubManager.Disconnected(Context.ConnectionId);
        Clients.AllExcept<IClientProxy>(Context.ConnectionId).SendAsync("onUserDisconnected", hubUserViewModel);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("onBusLateLocationSet")]
    public Task OnBusLateLocationSet(string data)
    {
        Clients.All.SendAsync("onBusLateLocation", data);
        return Task.CompletedTask;
    }

    [HubMethodName("StartTracker")]
    public Task StartTracker(string data)
    {
        Clients.All.SendAsync("onTrackerStarted", data);
        return Task.CompletedTask;
    }

    [HubMethodName("StopTracker")]
    public Task StopTracker(string data)
    {
        Clients.All.SendAsync("onTrackerStopped", data);
        return Task.CompletedTask;
    }

    [HubMethodName("SendMyLocation")]
    public Task SendMyLocation(string data)
    {
        Clients.All.SendAsync("onGetLocation", data);
        return Task.CompletedTask;
    }

    [HubMethodName("SendTrackerData")]
    public Task SendTrackerData(string data)
    {
        Clients.All.SendAsync("onGetTrackerData", data);
        return Task.CompletedTask;
    }

    [HubMethodName("HideMeFromTracker")]
    public Task HideMeFromTracker(string data)
    {
        Clients.All.SendAsync("onHideMeFromTracker", data);
        return Task.CompletedTask;
    }

    [HubMethodName("onBusLateCircleSet")]
    public Task OnBusLateCircleSet(string data)
    {
        Clients.All.SendAsync("onBusLateCircle", data);
        return Task.CompletedTask;
    }

    [HubMethodName("onSubscribe")]
    public Task OnSubscribe(string data)
    {
        logger.LogError(data);
        try
        {
            var user = JsonConvert.DeserializeObject<HubUserViewModel>(data);
            if (user == null)
                return Task.CompletedTask;
            hubManager.Subscribe(user, Context.ConnectionId);
            Clients.AllExcept<IClientProxy>(Context.ConnectionId).SendAsync("onUserConnected", user);
            if (user.EmpCode == "047785")
                Clients.Caller.SendAsync("onSubscribers", hubManager.GetUsersExcept(user.EmpCode));
        }
        catch (Exception ex)
        {
            logger.LogError(data);
            logger.LogError(ex.Message);
        }
        return Task.CompletedTask;
    }

    public async Task JoinRoom(string vehicleId)
    {
        var notificationHub = this;
        await notificationHub.Groups.AddToGroupAsync(notificationHub.Context.ConnectionId, vehicleId);
        await notificationHub.Clients.Group(vehicleId).SendAsync("UserJoined", notificationHub.Context.ConnectionId);
    }

    public async Task LeaveRoom(string vehicleId)
    {
        var notificationHub = this;
        await notificationHub.Groups.RemoveFromGroupAsync(notificationHub.Context.ConnectionId, vehicleId);
        await notificationHub.Clients.Group(vehicleId).SendAsync("UserLeft", notificationHub.Context.ConnectionId);
    }
}