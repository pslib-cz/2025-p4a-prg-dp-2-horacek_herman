using CiscoNetworkGame.Game;
using CiscoNetworkGame.Game.Helpers;
using CiscoNetworkGame.Game.Locations;
using CiscoNetworkGame.Logging;
using CiscoNetworkGame.Logging.ThirdParty;

namespace CiscoNetworkGame;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.WriteLine("     CISCO NETWORK ADVENTURE - Simulátor sítí");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");

        var analyticsLibrary = new AnalyticsLibrary();
        ILogger logger = new LoggerAdapter(analyticsLibrary);
        
        logger.Log("Hra byla spuštěna - Inicializace herního světa");

        var locationFactory = new LocationFactory();
        
        locationFactory.RegisterLocation(() => new VlanLab());
        locationFactory.RegisterLocation(() => new Ipv6Network());
        locationFactory.RegisterLocation(() => new RouterRoom());
        locationFactory.RegisterLocation(() => new SwitchTower());
        locationFactory.RegisterLocation(() => new ProfessorsOffice());
        locationFactory.RegisterLocation(() => new ProfessorsOffice());
        
        var chatGptHelper = new ChatGptHelper();
        var gameEngine = new GameEngine(chatGptHelper, logger);
        
        logger.Log("Všechny lokace byly zaregistrovány");
        
        Console.WriteLine("Začíná tvé dobrodružství v Cisco síti...\n");
        Console.WriteLine("(Stiskni CTRL+C pro ukončení)\n");
        
        int stepCounter = 0;
        int totalExperience = 0;
        int victories = 0;
        int defeats = 0;
        int maxHealth = 10;
        int currentHealth = maxHealth;

        // ============================================================
        // HLAVNÍ HERNÍ SMYČKA - interaktivní hra
        // ============================================================
            Console.WriteLine($"\n━━━━━━━━━━━━ KROK {stepCounter} ━━━━━━━━━━━━");
            
            // Zobrazení zdraví
            string healthBar = GetHealthBar(currentHealth, maxHealth);
            Console.WriteLine($"❤️  Životy: {healthBar} ({currentHealth}/{maxHealth})");
            Console.WriteLine($"📊 Skóre: {victories}V / {defeats}P | 🎯 XP: {totalExperience}");
            // 1. VSTUP DO NOVÉ LOKACE
            Location currentLocation = locationFactory.CreateRandomLocation();
            Console.WriteLine();
            Console.WriteLine(currentLocation.GetEntryMessage());
            logger.Log($"Hráč vstoupil do lokace: {currentLocation.Name}");
            Thread.Sleep(1500);
            
            // 2. SETKÁNÍ S NEPŘÍTELEM
            Console.WriteLine();
            Enemy enemy = currentLocation.CreateEnemy();
            Console.WriteLine(enemy.GetEncounterMessage());
            logger.Log($"Střet s nepřítelem: {enemy.Name} (obtížnost: {enemy.DifficultyLevel})");
            
            
            // 3. VOLBA HRÁČE - INTERAKTIVNÍ MENU
            PlayerAction action = gameEngine.GetPlayerAction(enemy);
            
            // 4. VYKONÁNÍ AKCE A VÝSLEDEK
            ActionResult result = gameEngine.ExecuteAction(action, enemy);
            
            Thread.Sleep(500);
            PlayerAction action = gameEngine.GetPlayerAction(enemy);ConsoleColor.Green;
                Console.WriteLine(result.Message);
                Console.ResetColor();
                victories++;
                logger.Log($"Vítězství nad: {enemy.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Message);
                Console.ResetColor();
                if (action != PlayerAction.Flee)
                {
                    defeats++;
                }
                logger.Log($"Prohra/útěk proti: {enemy.Name}");
            }
            
            // 5. ZÍSKÁNÍ ZKUŠENOSTÍ A ZTRÁTA ŽIVOTŮ
            if (result.Experience > 0)
            {
                totalExperience += result.Experience;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n+{result.Experience} XP získáno!");
            }
            
            if (result.DamageTaken > 0)
            {
                currentHealth -= result.DamageTaken;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n💔 Ztratil jsi {result.DamageTaken} {(result.DamageTaken == 1 ? "život" : result.DamageTaken <= 4 ? "životy" : "životů")}!");
                Console.ResetColor();
                
                if (currentHealth <= 0)
                {
                    logger.Log("Hráč zemřel - Game Over");
                    break;
                }
                else if (currentHealth <= 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("⚠️  VAROVÁNÍ: Máš už jen málo životů!");
                    Console.ResetColor();
                }
            }
            
            // Pauza před dalším krokem
            Console.WriteLine("\n[Stiskni ENTER pro pokračování...]");
            Console.ReadLine();
        }
        
        // GAME OVER
        Console.Clear();
        Console.WriteLine("\n╔═══════════════════════════════════════╗");
        Console.WriteLine("║            GAME OVER                 ║");
        Console.WriteLine("╚═══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("📊 FINÁLNÍ STATISTIKY:");
        Console.WriteLine($"   Kroků celkem: {stepCounter}");
        Console.WriteLine($"   Vítězství: {victories}");
        Console.WriteLine($"   Prohry: {defeats}");
        Console.WriteLine($"   Celkové XP: {totalExperience}");
        
        if (victories > 0)
        {
            double successRate = (double)victories / (victories + defeats) * 100;
            Console.WriteLine($"   Úspěšnost: {successRate:F1}%");
        }
        
        logger.Log($"Hra ukončena - Skóre: {victories}V/{defeats}P, XP: {totalExperience}");
        
        Console.WriteLine("\nDěkujeme za hru! Stiskni ENTER pro ukončení...");
        Console.ReadLine();
    }
    
    static string GetHealthBar(int current, int max)
    {
        int hearts = (int)Math.Ceiling((double)current / max * 10);
        string filled = new string('█', hearts);
        string empty = new string('░', 10 - hearts);
        
        ConsoleColor color = current > max / 2 ? ConsoleColor.Green :
                            current > max / 4 ? ConsoleColor.Yellow :
                            ConsoleColor.Red;
        
        return $"\x1b[38;5;{(color == ConsoleColor.Green ? "46" : color == ConsoleColor.Yellow ? "226" : "196")}m{filled}{empty}\x1b[0m";
    }
}
