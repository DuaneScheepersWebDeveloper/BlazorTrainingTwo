using EclipseWebAppClassLibrary.Data.Interfaces;
using EclipseWebAppClassLibrary.Data.Models;

namespace EclipseWebAppClassLibrary.Data.GridData;

public class AnalyticsData : IAnalyticsData
{
    List<Analytics> IAnalyticsData.GetAnalyticList()
    {
        var r = new Random();
        var dataList = new List<Analytics>();

        dataList.Add(new Analytics
        {
            IsSubscribed = true,
            WatchTimeHours = r.Next(100, 300),
            UserName = "NearPerfectUser",
            UserEmail = "Best@gmail.com",
            IsFemale = false
        });

        dataList.Add(new Analytics
        {
            IsSubscribed = true,
            WatchTimeHours = r.Next(0, 50),
            UserName = "NearPerfectUser2",
            UserEmail = "Best2@gmail.com",
            IsFemale = false
        });

        dataList.Add(new Analytics
        {
            IsSubscribed = false,
            WatchTimeHours = r.Next(100, 300),
            UserName = "NearPerfectUser3",
            UserEmail = "Best3@gmail.com",
            IsFemale = false
        });
        dataList.Add(new Analytics
        {
            IsSubscribed = true,
            WatchTimeHours = r.Next(100, 300),
            UserName = "NearPerfectUser4",
            UserEmail = "Best4@gmail.com",
            IsFemale = true
        });
        return dataList;
    }
}