# 📺 Demo nové interaktivní verze

## Co je nového?

### ✨ Interaktivní menu s volbami
Místo pasivního sledování hry teď máš plnou kontrolu! Po každém setkání s nepřítelem vybíráš ze **5 akcí**.

## Ukázka hraní

### Krok 1: Vstup do lokace
```
━━━━━━━━━━━━ KROK 1 ━━━━━━━━━━━━
📊 Skóre: 0V / 0P | 🎯 XP: 0

Vstupuješ do lokace: Router Room. 
Serverovna s racky plnými routerů. Všude blikají LED diody.
```

### Krok 2: Setkání s nepřítelem
```
Střetl ses s routerem zpíčenejrouter! 
Má pokazený RIP a routes se mažou!
```

### Krok 3: Tvoje volba!
```
╔════════════════════════════════════════╗
║         CO CHCEŠ UDĚLAT?              ║
╚════════════════════════════════════════╝

  [1] ⚔️  Útok - Přímý pokus o vyřešení problému
  [2] 🛡️  Obrana - Opatrný přístup (menší risk)
  [3] 💡 ChatGPT - Požádat o radu (zvýší šanci)
  [4] 🏃 Útěk - Přeskočit tuto lokaci
  [5] 🔍 Analýza - Důkladné prozkoumání (bonus šance)

Tvoje volba (1-5): _
```

### Příklad: Útok (volba 1)
```
Tvoje volba (1-5): 1

⚔️  Útočíš přímo na problém!

✓ Úspěch! Vyřešil jsi zpíčenejrouter!

+10 XP získáno!

[Stiskni ENTER pro pokračování...]
```

### Příklad: Analýza (volba 5)
```
Tvoje volba (1-5): 5

🔍 Důkladně analyzuješ problém...
    Spouštíš diagnostické příkazy...
    Kontroluješ konfigurační soubory...
    Hledáš root cause...

✓ Analýza úspěšná! Identifikoval a vyřešil jsi zkurvenejswitch!

+15 XP získáno!

[Stiskni ENTER pro pokračování...]
```

### Příklad: ChatGPT pomoc (volba 3)
```
Tvoje volba (1-5): 3

💡 Konzultuješ s ChatGPT...

ChatGPT radí: 'Možná potřebuješ no shutdown na interface?'

✓ S pomocí ChatGPT jsi vyřešil IPv6 Routing Error!

[Stiskni ENTER pro pokračování...]
```

### Příklad: Útěk před BOSS (volba 4)
```
⚠️⚠️⚠️ Vstupuješ do lokace: Kancelář profesora Prokeše.
⚠️  POZOR! Objevil se BOSS Prokeš (Bobik)! ⚠️

╔════════════════════════════════════════╗
║         CO CHCEŠ UDĚLAT?              ║
╚════════════════════════════════════════╝
...

Tvoje volba (1-5): 4

🏃 Rychle opouštíš lokaci...
Utekl jsi před Prokeš (Bobik). Někdy je diskréce lepší než statečnost.

[Stiskni ENTER pro pokračování...]
```

## Nová herní smyčka

```
while (true) {
    1. Zobraz lokaci
    2. Zobraz nepřítele
    3. ⭐ ZOBRAZ MENU S VOLBAMI ⭐
    4. ⭐ HRÁČ VYBERE AKCI ⭐
    5. Vykonej akci
    6. Zobraz výsledek
    7. Aktualizuj skóre a XP
    8. Čekej na ENTER
}
```

## Tracking postupu

### Po 5 krocích:
```
━━━━━━━━━━━━ KROK 5 ━━━━━━━━━━━━
📊 Skóre: 4V / 1P | 🎯 XP: 47
```

- **4V** = 4 vítězství
- **1P** = 1 prohra
- **47 XP** = Celkem získaných zkušeností

### Po 10 krocích:
```
━━━━━━━━━━━━ KROK 10 ━━━━━━━━━━━━
📊 Skóre: 7V / 2P | 🎯 XP: 89
```

## Změny v kódu

### Nové soubory:
- `Game/PlayerAction.cs` - Enum s akcemi
- `Game/GameEngine.cs` - Logika pro zpracování akcí

### Změny v Program.cs:
- Přidán interaktivní input
- Tracking skóre a XP
- Čekání na ENTER místo automatického pokračování

## Výhody nové verze

✅ **Interaktivní** - Hráč má kontrolu  
✅ **Strategické** - Různé akce pro různé situace  
✅ **Systém skórování** - Sledování postupu  
✅ **Zkušenosti** - Odměna za různé přístupy  
✅ **Tempo** - Hráč ovládá rychlost hry (ENTER)  
✅ **Replayability** - Každá hra může být jiná

## Spuštění

```bash
dotnet run
```

Pak stačí vybírat čísla 1-5 a stiskávat ENTER! 🎮
