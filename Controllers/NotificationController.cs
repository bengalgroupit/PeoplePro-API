
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PeoplePro.DbContext;
using PeoplePro.Dtos;
using PeoplePro.Utils;

namespace PeoplePro.Controllers;

[Route("api/v1/notification")]
[ApiController]
public class NotificationController(
    IHubContext<NotificationHub> hubContext,
    IConfiguration configuration)
    : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hubContext = hubContext;
    private readonly Notification _notification = new(configuration);

    [HttpPost("create")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationDto data)
    {
        var notificationController = this;
        var notificationId = notificationController._notification.Create(data.Title, data.Content);
        await notificationController._hubContext.Clients.All.SendAsync("onReceived", notificationId, data.Title, data.Content);
        return notificationController.Created(notificationId.ToString(), "Notification sent.");
    }

    [HttpGet("list/all")]
    public IActionResult GetNotificationListAll() => Ok(_notification.GetList());
}