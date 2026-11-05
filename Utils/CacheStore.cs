using Microsoft.Extensions.Caching.Memory;
using PeoplePro.DbContext;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.Utils;

public class CacheStore(IMemoryCache memoryCache, Hive hive, User user)
{
    public bool Clear(string key)
    {
        try
        {
            memoryCache.Remove(key);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public UserInformationViewModel GetUserInformation(string empCode)
    {
        var cacheKey = CacheKeyConst.CacheKeyUserInformation(empCode);

        if (memoryCache.TryGetValue(cacheKey, out UserInformationViewModel cachedValue))
            return cachedValue;

        var userInfo = user.GetUserInformation(empCode);
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7));

        memoryCache.Set(cacheKey, userInfo, cacheOptions);
        return userInfo;
    }

    public List<PolicyModel> GetPolicies()
    {
        if (memoryCache.TryGetValue(CacheKeyConst.CacheKeyPolicy, out List<PolicyModel> cachedValue))
            return cachedValue;

        var policies = hive.GetPolicies();
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        memoryCache.Set(CacheKeyConst.CacheKeyPolicy, policies, cacheOptions);
        return policies;
    }

    public List<NoticeModel> GetNotices()
    {
        if (memoryCache.TryGetValue(CacheKeyConst.CacheKeyNotice, out List<NoticeModel> cachedValue))
            return cachedValue;

        var notices = hive.GetNotices();
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        memoryCache.Set(CacheKeyConst.CacheKeyNotice, notices, cacheOptions);
        return notices;
    }

    public List<HolidayModel> GetHolidays()
    {
        if (memoryCache.TryGetValue(CacheKeyConst.CacheKeyHoliday, out List<HolidayModel> cachedValue))
            return cachedValue;

        var holidays = hive.GetHolidays();
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        memoryCache.Set(CacheKeyConst.CacheKeyHoliday, holidays, cacheOptions);
        return holidays;
    }

    public long GetLastNotificationId()
    {
        if (memoryCache.TryGetValue(CacheKeyConst.CacheKeyNotificationId, out long cachedValue))
            return cachedValue;

        var lastNotificationId = hive.GetLastNotificationId();
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        memoryCache.Set(CacheKeyConst.CacheKeyNotificationId, lastNotificationId, cacheOptions);
        return lastNotificationId;
    }

    public PopupNotification GetPopupNotification()
    {
        if (memoryCache.TryGetValue(CacheKeyConst.CacheKeyNotification, out PopupNotification cachedValue))
            return cachedValue;

        var popupNotification = hive.GetPopupNotification();
        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        memoryCache.Set(CacheKeyConst.CacheKeyNotification, popupNotification, cacheOptions);
        return popupNotification;
    }
}
