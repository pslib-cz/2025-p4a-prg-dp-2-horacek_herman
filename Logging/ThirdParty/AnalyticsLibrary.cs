namespace CiscoNetworkGame.Logging.ThirdParty;

public class AnalyticsLibrary
{
    public void TrackEvent(string eventName, int severity)
    {
        string severityText = severity switch
        {
            0 => "INFO",
            1 => "WARNING",
            2 => "ERROR",
            _ => "UNKNOWN"
        };
        
        Console.ForegroundColor = severity switch
        {
            0 => ConsoleColor.Cyan,
            1 => ConsoleColor.Yellow,
            2 => ConsoleColor.Red,
            _ => ConsoleColor.White
        };
        
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{severityText}] {eventName}");
        Console.ResetColor();
    }
}
