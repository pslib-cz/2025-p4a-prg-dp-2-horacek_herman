namespace CiscoNetworkGame.Game.Enemies;

public class VlanMisconfiguration : Enemy
{
    public VlanMisconfiguration()
    {
        Name = "VLAN Misconfiguration";
        Description = "Špatně nastavená VLAN, která blokuje komunikaci mezi segmenty sítě";
        DifficultyLevel = 1;
        Damage = 1;
        CorrectCommands = new List<string> 
        { 
            "vlan", 
            "switchport access vlan",
            "switchport trunk allowed vlan",
            "show vlan"
        };
        CommandHint = "Potřebuješ nakonfigurovat nebo zobrazit VLAN...";
    }

    public override string GetEncounterMessage()
    {
        return $"Narazil jsi na {Name}! Native VLAN není správně nastaveno a pakety se ztrácejí!";
    }
}
