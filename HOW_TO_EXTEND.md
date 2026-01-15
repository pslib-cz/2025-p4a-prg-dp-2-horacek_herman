# Jak přidat novou lokaci do hry

Tento návod ukazuje, jak snadno můžete přidat novou lokaci s novým nepřítelem do hry **bez změny hlavní herní smyčky**.

## Krok 1: Vytvoření nového nepřítele

Vytvořte novou třídu v složce `Game/Enemies/` dědící z `Enemy`:

```csharp
namespace CiscoNetworkGame.Game.Enemies;

public class DnsServerError : Enemy
{
    public DnsServerError()
    {
        Name = "DNS Server Error";
        Description = "DNS server s chybnou konfigurací zón";
        DifficultyLevel = 2;
    }

    public override string GetEncounterMessage()
    {
        return $"Narazil jsi na {Name}! DNS záznamy nefungují a nikdo se nedostane na web!";
    }
}
```

## Krok 2: Vytvoření nové lokace

Vytvořte novou třídu v složce `Game/Locations/` dědící z `Location`:

```csharp
using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class DnsServerRoom : Location
{
    public DnsServerRoom()
    {
        Name = "DNS Serverovna";
        Description = "Místnost s DNS servery. Na monitoru běží nslookup příkazy.";
    }

    public override Enemy CreateEnemy()
    {
        return new DnsServerError();
    }
}
```

## Krok 3: Registrace lokace

V souboru `Program.cs` přidejte jeden řádek pro registraci nové lokace:

```csharp
// V metodě Main(), po inicializaci locationFactory
locationFactory.RegisterLocation(() => new DnsServerRoom());
```

## To je vše!

**Žádná změna hlavní herní smyčky není potřebná!** Factory pattern se postará o zbytek.

## Příklad: Přidání více nepřátel do jedné lokace

Pokud chcete, aby lokace měla více možných nepřátel, můžete použít náhodný výběr:

```csharp
public override Enemy CreateEnemy()
{
    Random random = new Random();
    return random.Next(2) == 0 
        ? new DnsServerError() 
        : new DhcpServerError();
}
```

## Výhody tohoto přístupu

✅ **Žádná změna existujícího kódu** - přidáváte pouze nové třídy  
✅ **Dodržení Open/Closed principu** - otevřené pro rozšíření, uzavřené pro modifikaci  
✅ **Snadná údržba** - každá lokace a nepřítel je v separátním souboru  
✅ **Testovatelnost** - můžete testovat jednotlivé komponenty izolovaně  

## Experimentujte!

Zkuste přidat vlastní lokace jako:
- Firewall Room s nepřítelem "Blocked Port"
- WAN Connection s nepřítelem "Packet Loss"
- Cloud Server s nepřítelem "Bandwidth Throttling"
