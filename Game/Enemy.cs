namespace CiscoNetworkGame.Game;

public abstract class Enemy
{
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public int DifficultyLevel { get; protected set; }
    public int Damage { get; protected set; } = 1; // Kolik životů bere při neúspěchu
    public List<string> CorrectCommands { get; protected set; } = new(); // Správné Cisco příkazy
    public string CommandHint { get; protected set; } = string.Empty; // Nápověda

    public abstract string GetEncounterMessage();
    
    public virtual bool IsCommandCorrect(string command)
    {
        string normalizedCommand = command.Trim().ToLower();
        return CorrectCommands.Any(cmd => normalizedCommand.Contains(cmd.ToLower()));
    }
}
