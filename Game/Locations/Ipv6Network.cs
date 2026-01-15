using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class Ipv6Network : Location
{
    public Ipv6Network()
    {
        Name = "IPv6 Síť";
        Description = "Moderní datacenter s podporou IPv6. Všude vidíš hexadecimální adresy.";
    }

    public override Enemy CreateEnemy()
    {
        return new Ipv6RoutingError();
    }
}
