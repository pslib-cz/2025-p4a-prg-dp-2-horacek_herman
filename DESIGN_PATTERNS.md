# Návrhové vzory v projektu - Diagramy

## 1. Adapter Pattern - Logger System

```
┌─────────────────────────────────────────────────────────┐
│                     PROBLEM                              │
│  Máme stovky volání ILogger.Log() v kódu                │
│  Potřebujeme přejít na AnalyticsLibrary.TrackEvent()    │
│  AnalyticsLibrary nemůžeme měnit (externí .dll)         │
└─────────────────────────────────────────────────────────┘
                           ↓
┌─────────────────────────────────────────────────────────┐
│                    SOLUTION                              │
│                                                          │
│  ┌──────────────┐                                       │
│  │   ILogger    │  ← Původní rozhraní                   │
│  │  interface   │                                       │
│  └──────┬───────┘                                       │
│         │                                                │
│         │ implements                                     │
│         ↓                                                │
│  ┌──────────────┐        uses        ┌─────────────────┐│
│  │LoggerAdapter │ ──────────────────→│AnalyticsLibrary ││
│  │              │                    │  (třetí strana) ││
│  │ Log(msg)     │   TrackEvent(...)  │ TrackEvent()    ││
│  └──────────────┘                    └─────────────────┘│
│         ↑                                                │
│         │ používá celá aplikace                         │
│         │ (bez změny kódu!)                             │
└─────────────────────────────────────────────────────────┘
```

**Výhoda:** Kód aplikace zůstává stejný, pouze měníme instanci `ILogger`:
```csharp
// Stará verze:
ILogger logger = new OldLogger();

// Nová verze s adaptérem:
ILogger logger = new LoggerAdapter(new AnalyticsLibrary());
```

---

## 2. Factory Method Pattern - Location & Enemy

```
┌──────────────────────────────────────────────────────────┐
│                  ABSTRACT CLASSES                         │
│                                                           │
│  ┌────────────────┐                                      │
│  │   Location     │                                      │
│  │   (abstract)   │                                      │
│  ├────────────────┤                                      │
│  │ + Name         │                                      │
│  │ + Description  │                                      │
│  │ + CreateEnemy()│ ← Factory Method (abstract)         │
│  └────────┬───────┘                                      │
│           │                                               │
│           │ dědí                                         │
│           ↓                                               │
│  ┌────────────────┐   ┌────────────────┐                │
│  │   VlanLab      │   │  RouterRoom    │  atd...        │
│  ├────────────────┤   ├────────────────┤                │
│  │CreateEnemy()   │   │CreateEnemy()   │                │
│  │ return new     │   │ return new     │                │
│  │ VlanMis...()   │   │ Malfunction... │                │
│  └────────────────┘   └────────────────┘                │
│           │                    │                          │
│           │ vytváří           │ vytváří                  │
│           ↓                    ↓                          │
│  ┌────────────────┐   ┌────────────────┐                │
│  │VlanMisconfig.  │   │Malfunctioning  │                │
│  │    : Enemy     │   │Router : Enemy  │                │
│  └────────────────┘   └────────────────┘                │
└──────────────────────────────────────────────────────────┘
```

**Výhoda:** Každá lokace automaticky vytváří správného nepřítele. Přidání nové lokace nevyžaduje změnu hlavní logiky.

---

## 3. Factory Pattern - LocationFactory

```
┌──────────────────────────────────────────────────────────┐
│               REGISTRATION & CREATION                     │
│                                                           │
│  ┌────────────────────────────────────┐                  │
│  │      LocationFactory               │                  │
│  ├────────────────────────────────────┤                  │
│  │ - _locationCreators: List<Func>    │                  │
│  │ + RegisterLocation(Func<Location>) │                  │
│  │ + CreateRandomLocation(): Location │                  │
│  └─────────────┬──────────────────────┘                  │
│                │                                          │
│     Registrace │  Program.cs:                            │
│                │  factory.RegisterLocation(() => new ...) │
│                │                                          │
│                │  Vytvoření                               │
│                │  Location loc = factory.CreateRandom..() │
│                ↓                                          │
│  ┌──────┐  ┌──────┐  ┌──────┐  ┌──────┐                │
│  │VlanLab│ │IPv6  │  │Router│  │Switch│ atd...          │
│  │       │ │Network│ │Room  │  │Tower │                 │
│  └───────┘ └──────┘  └──────┘  └──────┘                 │
└──────────────────────────────────────────────────────────┘
```

**Výhoda:** 
- Přidání nové lokace = 1 řádek registrace
- Hlavní herní smyčka neví o konkrétních třídách
- Snadné přidání/odebrání lokací

---

## Tok hry s použitím vzorů

```
┌──────────────────────────────────────────────────────────┐
│                    MAIN GAME LOOP                         │
│                                                           │
│  while(true) {                                            │
│                                                           │
│    1. LocationFactory.CreateRandomLocation()             │
│       ↓                                                   │
│       [VlanLab | IPv6Network | RouterRoom | ...]         │
│       ↓                                                   │
│    2. location.CreateEnemy() // Factory Method           │
│       ↓                                                   │
│       [VlanMisconfiguration | IPv6RoutingError | ...]    │
│       ↓                                                   │
│    3. logger.Log("Vstup do lokace") // Adapter           │
│       ↓                                                   │
│       analyticsLibrary.TrackEvent(...)                   │
│       ↓                                                   │
│    4. Souboj + výsledek                                  │
│       ↓                                                   │
│    5. logger.Log("Výsledek") // Adapter                  │
│                                                           │
│  }                                                        │
└──────────────────────────────────────────────────────────┘
```

---

## Shrnutí výhod použitých vzorů

### Adapter Pattern (Logger)
✅ Umožňuje změnu knihovny bez úpravy aplikačního kódu  
✅ Abstrakce nad externí závislostí  
✅ Snadná změna logovacího systému v budoucnu  

### Factory Method Pattern (Location)
✅ Každá lokace vytváří vlastního nepřítele  
✅ Encapsulace logiky vytváření  
✅ Oddělení abstrakce od implementace  

### Factory Pattern (LocationFactory)
✅ Centralizovaná správa dostupných lokací  
✅ Dynamická registrace nových typů  
✅ Hlavní kód nezná konkrétní implementace  
✅ Open/Closed princip - otevřené pro rozšíření, uzavřené pro úpravy  
