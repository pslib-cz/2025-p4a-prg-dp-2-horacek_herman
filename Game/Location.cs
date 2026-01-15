namespace CiscoNetworkGame.Game;

public abstract class Location
{
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    public abstract Enemy CreateEnemy();

    public virtual string GetEntryMessage()
    {
        return $"Vstupuješ do lokace: {Name}. {Description}";
    }
}
