# 🎮 Herní mechanika - Volba akcí

## Interaktivní hraní

Po setkání s nepřítelem máš **5 možností**, jak situaci řešit. Každá akce má své výhody a nevýhody.

## Akce hráče

### ⚔️ 1. Útok
**Popis:** Přímý pokus o vyřešení problému bez přípravy.

- **Šance na úspěch:** Základní (100 - obtížnost × 5)%
- **Zkušenosti při úspěchu:** +10 XP
- **Zkušenosti při neúspěchu:** +5 XP
- **Doba trvání:** Rychlé
- **Kdy použít:** Když máš jistotu nebo chceš risknout

**Příklad:**
```
⚔️  Útočíš přímo na problém!
✓ Úspěch! Vyřešil jsi VLAN Misconfiguration!
+10 XP získáno!
```

---

### 🛡️ 2. Obrana
**Popis:** Opatrný a metodický přístup k problému.

- **Šance na úspěch:** Základní + 15%
- **Zkušenosti při úspěchu:** +7 XP
- **Zkušenosti při neúspěchu:** +3 XP
- **Doba trvání:** Mírně pomalejší
- **Kdy použít:** Když chceš vyšší jistotu, ale menší odměnu

**Příklad:**
```
🛡️  Postupuješ opatrně a analyzuješ situaci...
✓ Opatrný přístup se vyplatil! IPv6 Routing Error vyřešen!
+7 XP získáno!
```

---

### 💡 3. ChatGPT pomoc
**Popis:** Požádáš o radu od AI asistenta.

- **Šance na úspěch:** Základní + 25% (pokud je dostupný)
- **Zkušenosti:** 0 XP (učil ses od AI, ne vlastní zkušeností)
- **Dostupnost:** 70% šance, že je ChatGPT volný
- **Doba trvání:** Střední
- **Kdy použít:** Když potřebuješ pomoc s těžkým problémem a XP nejsou priorita

**Příklad:**
```
💡 Konzultuješ s ChatGPT...
ChatGPT radí: 'Možná potřebuješ no shutdown na interface?'
✓ S pomocí ChatGPT jsi vyřešil zpíčenejrouter!
```

**Když není dostupný:**
```
💡 Konzultuješ s ChatGPT...
ChatGPT právě není dostupný (zaneprázdněn jinými dotazy)...
Zkusíš to sám...
⚔️  Útočíš přímo na problém!
```

---

### 🏃 4. Útěk
**Popis:** Rychle opustíš lokaci bez pokusu o řešení.

- **Šance na úspěch:** 0% (automatický neúspěch)
- **Zkušenosti:** 0 XP
- **Doba trvání:** Nejrychlejší
- **Počítá se jako prohra:** Ne
- **Kdy použít:** Když chceš přeskočit příliš těžkého nepřítele (např. BOSS)

**Příklad:**
```
🏃 Rychle opouštíš lokaci...
Utekl jsi před Prokeš (Bobik). Někdy je diskréce lepší než statečnost.
```

---

### 🔍 5. Analýza
**Popis:** Důkladné prozkoumání problému se spuštěním diagnostiky.

- **Šance na úspěch:** Základní + 30% (nejvyšší!)
- **Zkušenosti při úspěchu:** +15 XP (nejvíce!)
- **Zkušenosti při neúspěchu:** +8 XP
- **Doba trvání:** Nejpomalejší (~4 sekundy)
- **Kdy použít:** Když máš čas a chceš maximální šanci i odměnu

**Příklad:**
```
🔍 Důkladně analyzuješ problém...
    Spouštíš diagnostické příkazy...
    Kontroluješ konfigurační soubory...
    Hledáš root cause...
✓ Analýza úspěšná! Identifikoval a vyřešil jsi zkurvenejswitch!
+15 XP získáno!
```

---

## Srovnání akcí

| Akce | Bonus šance | XP (úspěch) | XP (prohra) | Rychlost | Nejlepší pro |
|------|-------------|-------------|-------------|----------|--------------|
| ⚔️ Útok | +0% | 10 | 5 | ⚡⚡⚡ | Rychlé postupování |
| 🛡️ Obrana | +15% | 7 | 3 | ⚡⚡ | Bezpečný postup |
| 💡 ChatGPT | +25% | 0 | 0 | ⚡⚡ | Těžké úkoly |
| 🏃 Útěk | - | 0 | 0 | ⚡⚡⚡⚡ | Přeskočení BOSS |
| 🔍 Analýza | +30% | 15 | 8 | ⚡ | Maximum XP |

## Výpočet šance na úspěch

Základní vzorec:
```
Šance = 100 - (obtížnost_nepřítele × 5) + bonus_akce
```

### Příklady:

**VLAN Misconfiguration (obtížnost 1):**
- Útok: 100 - 5 = **95%**
- Obrana: 100 - 5 + 15 = **110%** (max 100%)
- ChatGPT: 100 - 5 + 25 = **120%** (max 100%)
- Analýza: 100 - 5 + 30 = **125%** (max 100%)

**zpíčenejrouter (obtížnost 3):**
- Útok: 100 - 15 = **85%**
- Obrana: 100 - 15 + 15 = **100%**
- ChatGPT: 100 - 15 + 25 = **110%** (max 100%)
- Analýza: 100 - 15 + 30 = **115%** (max 100%)

**BOSS Prokeš (obtížnost 10):**
- Útok: 100 - 50 = **50%**
- Obrana: 100 - 50 + 15 = **65%**
- ChatGPT: 100 - 50 + 25 = **75%**
- Analýza: 100 - 50 + 30 = **80%**

## Strategie hraní

### Pro maximalizaci XP:
Používej **Analýzu** na všechno. Je nejpomalejší, ale dává nejvíce bodů.

### Pro rychlý postup:
Používej **Útok** na lehké nepřátele, **Útěk** na těžké.

### Pro vysokou úspěšnost:
Používej **Analýzu** nebo **ChatGPT** na těžké nepřátele, **Útok** na lehké.

### Pro BOSS boj:
- **Analýza** (80% šance, 15 XP)
- **ChatGPT** (75% šance, 0 XP)
- **Útěk** (bezpečné přeskočení)

## Skórování

Hra sleduje:
- **Vítězství (V)** - Počet úspěšně vyřešených problémů
- **Prohry (P)** - Počet neúspěchů (útěk se nepočítá)
- **Celkové XP** - Součet všech získaných zkušeností

Zobrazení:
```
📊 Skóre: 5V / 2P | 🎯 XP: 67
```

## Tipy

💡 Analýza má nejlepší poměr šance/XP, ale trvá nejdéle  
💡 ChatGPT je skvělý pro BOSS, ale nedává XP  
💡 Útěk nezhoršuje tvoje skóre - není to prohra  
💡 U lehkých nepřátel (obtížnost 1-2) je útok efektivní  
💡 U těžkých nepřátel (obtížnost 8+) zvažuj Analýzu nebo ChatGPT
