namespace CiscoNetworkGame.Game;

public class LocationFactory
{
    private readonly List<Func<Location>> _locationCreators = new();
    private readonly Random _random = new();

    public void RegisterLocation(Func<Location> creator)
    {
        _locationCreators.Add(creator);
    }

    public Location CreateRandomLocation()
    {
        if (_locationCreators.Count == 0)
        {
            throw new InvalidOperationException("Žádné lokace nejsou zaregistrovány!");
        }

        int index = _random.Next(_locationCreators.Count);
        return _locationCreators[index]();
    }
}
