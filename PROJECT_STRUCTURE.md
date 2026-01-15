# 📁 Struktura projektu

```
.
├── CiscoNetworkGame.csproj          # Projektový soubor .NET
├── Program.cs                        # Hlavní vstupní bod - herní smyčka
├── README.md                         # Hlavní dokumentace projektu
├── DESIGN_PATTERNS.md                # Podrobný popis návrhových vzorů s diagramy
├── HOW_TO_EXTEND.md                  # Návod na přidání nových lokací
├── EXAMPLE_OUTPUT.md                 # Ukázky výstupu aplikace
│
├── Logging/                          # 📂 Logger systém (ADAPTER PATTERN)
│   ├── ILogger.cs                    # Původní rozhraní pro logování
│   ├── LoggerAdapter.cs              # Adaptér ILogger → AnalyticsLibrary
│   └── ThirdParty/
│       └── AnalyticsLibrary.cs       # Simulace externí knihovny (.dll)
│
└── Game/                             # 📂 Herní logika
    ├── Enemy.cs                      # Abstraktní třída nepřítele
    ├── Location.cs                   # Abstraktní třída lokace (FACTORY METHOD)
    ├── LocationFactory.cs            # Factory pro vytváření lokací
    │
    ├── Enemies/                      # 📂 Konkrétní nepřátelé
    │   ├── VlanMisconfiguration.cs   # VLAN problém
    │   ├── Ipv6RoutingError.cs       # IPv6 routing chyba
    │   ├── MalfunctioningRouter.cs   # zpíčenejrouter
    │   ├── FaultySwitch.cs           # zkurvenejswitch
    │   └── ProfessorProkes.cs        # BOSS - Prokeš (Bobik)
    │
    ├── Locations/                    # 📂 Konkrétní lokace
    │   ├── VlanLab.cs                # VLAN Laboratoř
    │   ├── Ipv6Network.cs            # IPv6 Síť
    │   ├── RouterRoom.cs             # Router Room
    │   ├── SwitchTower.cs            # Switch Tower
    │   └── ProfessorsOffice.cs       # Kancelář profesora (BOSS lokace)
    │
    └── Helpers/                      # 📂 Pomocné třídy
        └── ChatGptHelper.cs          # ChatGPT pomocník
```

## 📊 Statistiky

- **Celkem C# souborů**: 18
- **Řádků kódu**: ~600
- **Návrhové vzory**: 3 (Adapter, Factory Method, Factory)
- **Lokací**: 5
- **Nepřátel**: 5
- **Dokumentačních souborů**: 4

## 🎯 Klíčové soubory

### Pro pochopení Adapter pattern
- [Logging/ILogger.cs](Logging/ILogger.cs)
- [Logging/LoggerAdapter.cs](Logging/LoggerAdapter.cs)
- [Logging/ThirdParty/AnalyticsLibrary.cs](Logging/ThirdParty/AnalyticsLibrary.cs)

### Pro pochopení Factory pattern
- [Game/Location.cs](Game/Location.cs) - Factory Method
- [Game/LocationFactory.cs](Game/LocationFactory.cs) - Factory
- [Program.cs](Program.cs) - Registrace lokací

### Pro přidání nového obsahu
- Vytvořte novou třídu v `Game/Locations/`
- Vytvořte novou třídu v `Game/Enemies/`
- Zaregistrujte v `Program.cs`

## 🔧 Příkazy

```bash
# Kompilace
dotnet build

# Spuštění
dotnet run

# Čištění build artefaktů
dotnet clean
```

## 📚 Dokumentace

Každý soubor obsahuje XML komentáře vysvětlující účel třídy a metod. Pro detailní informace o návrhových vzorech viz [DESIGN_PATTERNS.md](DESIGN_PATTERNS.md).
