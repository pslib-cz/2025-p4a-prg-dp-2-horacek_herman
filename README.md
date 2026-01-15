# Cisco Network Adventure - Návrhové vzory v praxi

## 📋 Popis projektu

Interaktivní konzolová hra simulující řešení síťových problémů v Cisco prostředí. Projekt demonstruje praktickou implementaci návrhových vzorů pro řešení reálných problémů vývoje software.

## 🎯 Použité návrhové vzory

### 1. Adapter Pattern (Adaptér)

**Scénář:** Aplikace používá rozhraní `ILogger` na mnoha místech v kódu. Je potřeba přejít na novou analytickou knihovnu třetí strany `AnalyticsLibrary`, kterou není možné modifikovat (dodána jako .dll).

**Řešení:** Adaptér `LoggerAdapter` implementuje původní rozhraní `ILogger` a interně volá metody nové knihovny `AnalyticsLibrary`.

**Výhoda:** Místo změny kódu na stovkách míst stačilo změnit pouze vytvoření instance:
```csharp
ILogger logger = new LoggerAdapter(new AnalyticsLibrary());
```

**Implementace:**
- `ILogger` - rozhraní pro logování
- `LoggerAdapter` - adaptér přizpůsobující ILogger na AnalyticsLibrary
- `AnalyticsLibrary` - simulace externí knihovny

**Demonstrovaná výhoda:**
- Umožňuje přechod na novou technologii bez refaktoringu celého kódu
- Zachovává zpětnou kompatibilitu
- Izoluje závislost na externí knihovně

---

### 2. Factory Method Pattern (Tovární metoda)

**Popis:** Každá lokace ve hře má odpovědnost za vytvoření svého specifického nepřítele. Abstraktní třída `Location` definuje metodu `CreateEnemy()`, kterou každá konkrétní lokace implementuje po svém.

**Implementace:**
```csharp
public abstract class Location
{
    public abstract Enemy CreateEnemy();
}

public class VlanLab : Location
{
    public override Enemy CreateEnemy()
    {
        return new VlanMisconfiguration();
    }
}
```

**Výhoda:** Každá lokace zapouzdřuje logiku vytváření svého nepřítele. Přidání nové lokace nevyžaduje změnu existujícího kódu.

**Proč tento vzor:**
- Dodržuje Single Responsibility Principle
- Umožňuje polymorfní vytváření objektů
- Lokace a nepřítel jsou logicky svázáni

---

### 3. Factory Pattern (Továrna)

**Popis:** `LocationFactory` spravuje registraci a vytváření různých typů lokací. Umožňuje dynamické přidávání nových lokací bez změny hlavní herní smyčky.

**Implementace:**
```csharp
var factory = new LocationFactory();

factory.RegisterLocation(() => new VlanLab());
factory.RegisterLocation(() => new RouterRoom());

Location location = factory.CreateRandomLocation();
```

**Výhoda:** 
- Hlavní kód hry neví o konkrétních třídách lokací
- Nové lokace lze přidat pouze registrací
- Centralizovaná správa dostupných lokací

**Proč tento vzor:**
- Dodržuje Open/Closed Principle (otevřené pro rozšíření, uzavřené pro modifikaci)
- Umožňuje snadné testování (lze předat mock factory)
- Flexibilní konfigurace hry

---

## 🎮 Herní mechanika

Hra o zapojování Cisco sítí s interaktivními volbami:
- **Životy** - začínáš s 10 životy, při chybě ztrácíš životy
- **Cisco příkazy** - při útoku musíš zadat správný Cisco příkaz
- **5 akcí** - Útok (Cisco příkazy), Obrana, ChatGPT, Útěk, Analýza
- **XP systém** - získáváš zkušenosti za řešení problémů

### Síťové prvky:
- VLAN - konfigurace virtuálních sítí
- IPv6 - IPv6 routing
- Router "zpíčenejrouter" - problematický router
- Switch "zkurvenejswitch" - switch s problémy
- BOSS Prokeš (Bobik) - finální výzva

## 🚀 Spuštění

```bash
dotnet build
dotnet run
```

## 📁 Struktura projektu

```
├── Logging/
│   ├── ILogger.cs              # Původní rozhraní
│   ├── LoggerAdapter.cs        # ADAPTER PATTERN
│   └── ThirdParty/
│       └── AnalyticsLibrary.cs # Externí knihovna
├── Game/
│   ├── Location.cs             # FACTORY METHOD PATTERN
│   ├── LocationFactory.cs      # FACTORY PATTERN
│   ├── Enemy.cs
│   ├── GameEngine.cs
│   ├── Locations/              # Konkrétní lokace
│   └── Enemies/                # Konkrétní nepřátelé
└── Program.cs                  # Hlavní herní smyčka
```

## 🔧 Rozšíření

Přidání nové lokace vyžaduje pouze:
1. Vytvoření třídy dědící z `Location`
2. Implementaci metody `CreateEnemy()`
3. Registraci v `Program.cs`: `factory.RegisterLocation(() => new NovaLokace());`

**Žádná změna hlavní herní smyčky není potřebná!**

## 📚 Závěr

Projekt demonstruje, jak návrhové vzory řeší reálné problémy:
- **Adapter** - integrace nové technologie bez velkých změn
- **Factory Method** - delegace vytváření na podtřídy
- **Factory** - flexibilní a rozšiřitelná architektura

Tyto vzory společně vytvářejí čistý, udržovatelný a snadno rozšiřitelný kód.
