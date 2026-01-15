using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class RouterRoom : Location
{
    public RouterRoom()
    {
        Name = "Router Room";
        Description = "Serverovna s racky plnými routerů. Všude blikají LED diody.";
    }

    public override Enemy CreateEnemy()
    {
        return new MalfunctioningRouter();
    }
}
