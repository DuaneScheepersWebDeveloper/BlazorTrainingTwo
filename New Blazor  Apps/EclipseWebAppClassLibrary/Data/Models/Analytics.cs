namespace EclipseWebAppClassLibrary.Data.Models;

public class Analytics
{
    private bool IsFemaleSubscriber;
    public bool IsSubscribed { get; set; }
    public int WatchTimeHours { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }

    public bool IsFemale
    {
        get => false;
        set => IsFemaleSubscriber = value;
    }
}