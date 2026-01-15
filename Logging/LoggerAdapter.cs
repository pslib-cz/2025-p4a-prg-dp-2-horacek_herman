using CiscoNetworkGame.Logging.ThirdParty;

namespace CiscoNetworkGame.Logging;

public class LoggerAdapter : ILogger
{
    private readonly AnalyticsLibrary _analyticsLibrary;
    private int _defaultSeverity;

    public LoggerAdapter(AnalyticsLibrary analyticsLibrary, int defaultSeverity = 0)
    {
        _analyticsLibrary = analyticsLibrary;
        _defaultSeverity = defaultSeverity;
    }

    public void Log(string message)
    {
        // Přizpůsobení: jednoduchá zpráva -> analytické volání s eventName a severity
        // Můžeme použít heuristiku pro určení závažnosti na základě klíčových slov
        int severity = DetermineSeverity(message);
        _analyticsLibrary.TrackEvent(message, severity);
    }

    private int DetermineSeverity(string message)
    {
        string lowerMessage = message.ToLower();
        
        if (lowerMessage.Contains("error") || lowerMessage.Contains("fatal") || 
            lowerMessage.Contains("poražen") || lowerMessage.Contains("zemřel"))
        {
            return 2; // ERROR
        }
        
        if (lowerMessage.Contains("warning") || lowerMessage.Contains("varování") || 
            lowerMessage.Contains("nebezpečí") || lowerMessage.Contains("boss"))
        {
            return 1; // WARNING
        }
        
        return 0; // INFO
    }
}
