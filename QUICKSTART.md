# 🚀 Quick Start Guide

## Rychlé spuštění

```bash
# 1. Kompilace projektu
dotnet build

# 2. Spuštění hry
dotnet run
```

## Co se stane?

1. **Úvodní obrazovka** - Zobrazí se banner aplikace
2. **Inicializace** - Logger zaloguje spuštění (přes Adapter pattern)
3. **Interaktivní hra** - V každém kroku vybíráš akci

Každý krok:
- Náhodný výběr lokace (Factory pattern)
- Vytvoření nepřítele pro lokaci (Factory Method pattern)
- **Zobrazení menu s možnostmi akcí**
- **Ty vybereš, co chceš udělat (1-5)**
- Vykonání akce s výsledkem
- Získání zkušeností (XP) a aktualizace skóre
- Logování událostí (Adapter pattern)
- Stiskni ENTER pro další krok

## První spuštění

```
═══════════════════════════════════════════════════════
     CISCO NETWORK ADVENTURE - Simulátor sítí
═══════════════════════════════════════════════════════

[10:15:32] [INFO] Hra byla spuštěna - Inicializace herního světa
[10:15:32] [INFO] Všechny lokace byly zaregistrovány
Začíná tvé dobrodružství v Cisco síti...

(Stiskni CTRL+C pro ukončení)


━━━━━━━━━━━━ KROK 1 ━━━━━━━━━━━━
📊 Skóre: 0V / 0P | 🎯 XP: 0

Vstupuješ do lokace: VLAN Laboratoř...

Narazil jsi na VLAN Misconfiguration!

╔════════════════════════════════════════╗
║         CO CHCEŠ UDĚLAT?              ║
╚════════════════════════════════════════╝

  [1] ⚔️  Útok - Přímý pokus o vyřešení problému
  [2] 🛡️  Obrana - Opatrný přístup (menší risk)
  [3] 💡 ChatGPT - Požádat o radu (zvýší šanci)
  [4] 🏃 Útěk - Přeskočit tuto lokaci
  [5] 🔍 Analýza - Důkladné prozkoumání (bonus šance)

Tvoje volba (1-5):
```

## Ukončení

Stiskněte `CTRL+C` pro ukončení aplikace.

## Co hledat v kódu?

### 1. Adapter Pattern
📂 [Logging/LoggerAdapter.cs](Logging/LoggerAdapter.cs)

```csharp
// Místo změny stovek volání, změníme pouze instanci:
ILogger logger = new LoggerAdapter(new AnalyticsLibrary());
```

### 2. Factory Pattern
📂 [Game/LocationFactory.cs](Game/LocationFactory.cs)

```csharp
// Registrace:
locationFactory.RegisterLocation(() => new VlanLab());

// Vytvoření:
Location location = locationFactory.CreateRandomLocation();
```

### 3. Factory Method Pattern
📂 [Game/Location.cs](Game/Location.cs)

```csharp
// Každá lokace vytváří vlastního nepřítele:
public abstract Enemy CreateEnemy();
```

## Přidání nové lokace?

Viz [HOW_TO_EXTEND.md](HOW_TO_EXTEND.md) - Tři jednoduché kroky!

## Potřebujete pomoc?

- 📖 [README.md](README.md) - Hlavní dokumentace
- 🎨 [DESIGN_PATTERNS.md](DESIGN_PATTERNS.md) - Diagramy návrhových vzorů
- 📁 [PROJECT_STRUCTURE.md](PROJECT_STRUCTURE.md) - Struktura projektu
- 📺 [EXAMPLE_OUTPUT.md](EXAMPLE_OUTPUT.md) - Ukázky výstupu
