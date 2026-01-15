using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class SwitchTower : Location
{
    public SwitchTower()
    {
        Name = "Switch Tower";
        Description = "Vysoká věž plná Cisco Catalyst switchů. Slyšíš hučení ventilátorů.";
    }

    public override Enemy CreateEnemy()
    {
        return new FaultySwitch();
    }
}
