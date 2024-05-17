using EclipseWebAppClassLibrary.Data.GridData;
using EclipseWebAppClassLibrary.Data.Interfaces;
using EclipseWebAppClassLibrary.Data.Models;
using Microsoft.AspNetCore.Components;

namespace EclipsePageLibrary.EclipsePages;

public partial class ReusableTableComponentTemplate : ComponentBase
{
    [Inject] private IAnalyticsData? AnalyticsData { get; set; }

    [Inject] private ICarData? CarData { get; set; }

    private List<Analytics>? AnalyticsList { get; set; }

    private List<Car>? CarList { get; set; }

    protected override void OnInitialized()
    {
        if (AnalyticsData != null) AnalyticsList = AnalyticsData.GetAnalyticList();

        if (CarData != null) CarList = CarData.GetCarList();
    }
}