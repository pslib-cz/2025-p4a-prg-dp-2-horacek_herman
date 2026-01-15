using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class VlanLab : Location
{
    public VlanLab()
    {
        Name = "VLAN Laboratoř";
        Description = "Místnost plná switchů. Na stěně visí plakát s 802.1Q standardem.";
    }

    public override Enemy CreateEnemy()
    {
        return new VlanMisconfiguration();
    }
}
