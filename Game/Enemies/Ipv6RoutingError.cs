namespace CiscoNetworkGame.Game.Enemies;

public class Ipv6RoutingError : Enemy
{
    public Ipv6RoutingError()
    {
        Name = "IPv6 Routing Error";
        Description = "Nefunkční IPv6 routing kvůli chybějící Link-Local adrese";
        DifficultyLevel = 2;
        Damage = 1;
        CorrectCommands = new List<string> 
        { 
            "ipv6 unicast-routing",
            "ipv6 address",
            "show ipv6 route",
            "ipv6 route"
        };
        CommandHint = "Zkus povolit IPv6 routing nebo nastavit adresu...";
    }

    public override string GetEncounterMessage()
    {
        return $"Objevil se {Name}! FE80::/10 nefunguje a OSPFv3 je v chaosu!";
    }
}
