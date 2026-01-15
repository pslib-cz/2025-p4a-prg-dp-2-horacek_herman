using CiscoNetworkGame.Game.Helpers;
using CiscoNetworkGame.Logging;

namespace CiscoNetworkGame.Game;

public class GameEngine
{
    private readonly ChatGptHelper _chatGptHelper;
    private readonly ILogger _logger;
    private readonly Random _random;

    public GameEngine(ChatGptHelper chatGptHelper, ILogger logger)
    {
        _chatGptHelper = chatGptHelper;
        _logger = logger;
        _random = new Random();
    }

    public PlayerAction GetPlayerAction(Enemy enemy)
    {
        Console.WriteLine("\n╔════════════════════════════════════════╗");
        Console.WriteLine("║         CO CHCEŠ UDĚLAT?              ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("  [1] ⚔️  Útok - Musíš zadat správný Cisco příkaz!");
        Console.WriteLine("  [2] 🛡️  Obrana - Opatrný přístup (menší risk)");
        Console.WriteLine("  [3] 💡 ChatGPT - Požádat o radu (zvýší šanci)");
        Console.WriteLine("  [4] 🏃 Útěk - Přeskočit tuto lokaci");
        Console.WriteLine("  [5] 🔍 Analýza - Důkladné prozkoumání (bonus šance)");
        Console.WriteLine();
        Console.Write("Tvoje volba (1-5): ");

        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
            {
                return choice switch
                {
                    1 => PlayerAction.Attack,
                    2 => PlayerAction.Defend,
                    3 => PlayerAction.UseHelper,
                    4 => PlayerAction.Flee,
                    5 => PlayerAction.Analyze,
                    _ => PlayerAction.Attack
                };
            }
            Console.Write("Neplatná volba! Zadej číslo 1-5: ");
        }
    }

    public ActionResult ExecuteAction(PlayerAction action, Enemy enemy)
    {
        Console.WriteLine();
        
        switch (action)
        {
            case PlayerAction.Attack:
                return ExecuteAttack(enemy);
            
            case PlayerAction.Defend:
                return ExecuteDefend(enemy);
            
            case PlayerAction.UseHelper:
                return ExecuteUseHelper(enemy);
            
            case PlayerAction.Flee:
                return ExecuteFlee(enemy);
            
            case PlayerAction.Analyze:
                return ExecuteAnalyze(enemy);
            
            default:
                return ExecuteAttack(enemy);
        }
    }

    private ActionResult ExecuteAttack(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("⚔️  ÚTOK - Musíš zadat správný Cisco příkaz!");
        Console.ResetColor();
        Console.WriteLine();
        
        // Zobrazení nápovědy
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"💡 Nápověda: {enemy.CommandHint}");
        Console.ResetColor();
        Console.WriteLine();
        
        // 3 pokusy
        int attempts = 3;
        bool success = false;
        
        for (int i = 1; i <= attempts; i++)
        {
            Console.Write($"Zadej Cisco příkaz (pokus {i}/{attempts}): ");
            string? command = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(command))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Nezadal jsi žádný příkaz!");
                Console.ResetColor();
                continue;
            }
            
            _logger.Log($"Hráč zadal příkaz: {command}");
            
            if (enemy.IsCommandCorrect(command))
            {
                success = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Správně! Příkaz '{command}' vyřešil problém!");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✗ Špatný příkaz! '{command}' nefunguje...");
                Console.ResetColor();
                
                if (i < attempts)
                {
                    Console.WriteLine("Zkus to znovu!");
                    Console.WriteLine();
                }
            }
        }
        
        Thread.Sleep(500);
        
        return new ActionResult
        {
            Success = success,
            Message = success 
                ? $"✓ Úspěch! Vyřešil jsi {enemy.Name}!" 
                : $"✗ Nepodařilo se! {enemy.Name} tě porazil!",
            Experience = success ? 10 : 5,
            DamageTaken = success ? 0 : enemy.Damage
        };
    }

    private ActionResult ExecuteDefend(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🛡️  Postupuješ opatrně a analyzuješ situaci...");
        Console.ResetColor();
        _logger.Log($"Hráč zvolil obranu proti: {enemy.Name}");
        
        Thread.Sleep(1500);
        
        // Vyšší šance (bonus +15%), ale méně zkušeností, menší damage
        int baseChance = 100 - (enemy.DifficultyLevel * 5) + 15;
        bool success = _random.Next(100) < baseChance;
        
        return new ActionResult
        {
            Success = success,
            Message = success 
                ? $"✓ Opatrný přístup se vyplatil! {enemy.Name} vyřešen!" 
                : $"✗ I opatrnost nepomohla, {enemy.Name} zůstal neřešen.",
            Experience = success ? 7 : 3,
            DamageTaken = success ? 0 : Math.Max(1, enemy.Damage - 1) // Obrana snižuje damage
        };
    }

    private ActionResult ExecuteUseHelper(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("💡 Konzultuješ s ChatGPT...");
        Console.ResetColor();
        
        Thread.Sleep(1000);
        
        if (!_chatGptHelper.IsAvailable())
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("ChatGPT právě není dostupný (zaneprázdněn jinými dotazy)...");
            Console.ResetColor();
            _logger.Log("ChatGPT nebyl dostupný");
            
            Thread.Sleep(1000);
            Console.WriteLine("Zkusíš to sám...");
            return ExecuteAttack(enemy);
        }
        
        string tip = _chatGptHelper.GetRandomTip();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{tip}");
        Console.ResetColor();
        _logger.Log("ChatGPT poskytl radu");
        
        Thread.Sleep(1500);
        
        // Velký bonus (+25%), ale žádné zkušenosti (učil se od AI)
        int baseChance = 100 - (enemy.DifficultyLevel * 5) + 25;
        bool success = _random.Next(100) < baseChance;
        
        return new ActionResult
        {
            Success = success,
            Message = success 
                ? $"✓ S pomocí ChatGPT jsi vyřešil {enemy.Name}!" 
                : $"✗ Ani ChatGPT nepomohl, {enemy.Name} je moc složitý!",
            Experience = 0, // Žádné zkušenosti při použití AI
            DamageTaken = success ? 0 : enemy.Damage
        };
    }

    private ActionResult ExecuteFlee(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("🏃 Rychle opouštíš lokaci...");
        Console.ResetColor();
        _logger.Log($"Hráč utekl před: {enemy.Name}");
        
        Thread.Sleep(1000);
        
        return new ActionResult
        {
            Success = false,
            Message = $"Utekl jsi před {enemy.Name}. Někdy je diskréce lepší než statečnost.",
            Experience = 0,
            DamageTaken = 0 // Útěk nezpůsobuje damage
        };
    }

    private ActionResult ExecuteAnalyze(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🔍 Důkladně analyzuješ problém...");
        Console.WriteLine("    Spouštíš diagnostické příkazy...");
        Console.ResetColor();
        _logger.Log($"Hráč analyzuje: {enemy.Name}");
        
        Thread.Sleep(2000);
        
        Console.WriteLine("    Kontroluješ konfigurační soubory...");
        Thread.Sleep(1000);
        Console.WriteLine("    Hledáš root cause...");
        Thread.Sleep(1000);
        
        // Nejlepší šance (+30%), nejvíce zkušeností, ale trvá nejdéle
        int baseChance = 100 - (enemy.DifficultyLevel * 5) + 30;
        bool success = _random.Next(100) < baseChance;
        
        return new ActionResult
        {
            Success = success,
            Message = success 
                ? $"✓ Analýza úspěšná! Identifikoval a vyřešil jsi {enemy.Name}!" 
                : $"✗ Analýza selhala, {enemy.Name} zůstává nevyřešený.",
            Experience = success ? 15 : 8,
            DamageTaken = success ? 0 : enemy.Damage
        };
    }
}

public class ActionResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int Experience { get; set; }
    public int DamageTaken { get; set; } = 0;
}
