namespace CiscoNetworkGame.Game.Enemies;

public class ProfessorProkes : Enemy
{
    public ProfessorProkes()
    {
        Name = "Prokeš (Bobik)";
        Description = "Hlavní boss - profesor počítačových sítí, mistr Cisco konfigurace";
        DifficultyLevel = 10;
        Damage = 3;
        CorrectCommands = new List<string> 
        { 
            "router bgp",
            "neighbor",
            "mpls",
            "qos",
            "class-map",
            "policy-map"
        };
        CommandHint = "Bobik čeká pokročilou konfiguraci BGP, MPLS nebo QoS...";
    }

    public override string GetEncounterMessage()
    {
        return $"⚠️  POZOR! Objevil se BOSS {Name}! ⚠️\n" +
               "Chystá se ti dát zkouškový test na BGP, MPLS a QoS najednou!\n" +
               "Bobik ti ukazuje diagram s AS path-prepending a říká 'A teď to nakonfiguruj!'";
    }
}
