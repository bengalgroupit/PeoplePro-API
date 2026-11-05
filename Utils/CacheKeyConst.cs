 

namespace PeoplePro.Utils;

public class CacheKeyConst
{
    public static readonly string CacheKeyPolicy = "ck-policy";
    public static readonly string CacheKeyNotice = "ck-notice";
    public static readonly string CacheKeyHoliday = "ck-holiday";
    public static readonly string CacheKeyNotification = "ck-notification";
    public static readonly string CacheKeyNotificationId = "ck-notification-id";

    public static string CacheKeyUserInformation(string empCode) => "ck-user-" + empCode;
}