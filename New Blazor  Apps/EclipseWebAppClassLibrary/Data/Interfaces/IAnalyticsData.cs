using EclipseWebAppClassLibrary.Data.Models;

namespace EclipseWebAppClassLibrary.Data.Interfaces;

public interface IAnalyticsData
{
    List<Analytics> GetAnalyticList();
}