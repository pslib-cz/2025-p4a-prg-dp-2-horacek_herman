namespace CiscoNetworkGame.Game.Enemies;

public class MalfunctioningRouter : Enemy
{
    public MalfunctioningRouter()
    {
        Name = "zpíčenejrouter";
        Description = "Router s pokazeným firmware, který náhodně restartuje";
        DifficultyLevel = 3;
        Damage = 2;
        CorrectCommands = new List<string> 
        { 
            "reload",
            "copy running-config startup-config",
            "write memory",
            "show version",
            "router rip"
        };
        CommandHint = "Možná potřebuješ restartovat nebo uložit konfiguraci...";
    }

    public override string GetEncounterMessage()
    {
        return $"Střetl ses s routerem {Name}! Má pokazený RIP a routes se mažou!";
    }
}
