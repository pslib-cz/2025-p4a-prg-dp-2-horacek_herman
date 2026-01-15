namespace CiscoNetworkGame.Game.Enemies;

public class FaultySwitch : Enemy
{
    public FaultySwitch()
    {
        Name = "zkurvenejswitch";
        Description = "Switch s přeplněnou MAC address tabulkou";
        DifficultyLevel = 2;
        Damage = 1;
        CorrectCommands = new List<string> 
        { 
            "spanning-tree",
            "clear mac address-table",
            "show mac address-table",
            "spanning-tree mode"
        };
        CommandHint = "Zkus vyřešit Spanning Tree nebo vymazat MAC tabulku...";
    }

    public override string GetEncounterMessage()
    {
        return $"Potkal jsi switch {Name}! Spanning Tree Protocol je rozbitý a máš broadcast storm!";
    }
}
