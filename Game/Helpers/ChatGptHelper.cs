namespace CiscoNetworkGame.Game.Helpers;

public class ChatGptHelper
{
    private readonly Random _random = new();
    private readonly List<string> _tips = new()
    {
        "ChatGPT šeptá: 'Zkus show running-config...'",
        "ChatGPT radí: 'Možná potřebuješ no shutdown na interface?'",
        "ChatGPT připomíná: 'Nezapomněl jsi na copy running-config startup-config?'",
        "ChatGPT navrhuje: 'Co třeba debug ip routing?'",
        "ChatGPT říká: 'VLAN musí existovat v databázi, než ji přiřadíš!'",
        "ChatGPT varuje: 'Pozor na default gateway!'"
    };

    public string GetRandomTip()
    {
        return _tips[_random.Next(_tips.Count)];
    }

    public bool IsAvailable()
    {
        // ChatGPT je dostupný s 30% pravděpodobností
        return _random.Next(100) < 30;
    }
}
