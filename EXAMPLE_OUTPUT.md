# Ukázka běhu aplikace

## Začátek hry

```
═══════════════════════════════════════════════════════
     CISCO NETWORK ADVENTURE - Simulátor sítí
═══════════════════════════════════════════════════════

[09:51:05] [INFO] Hra byla spuštěna - Inicializace herního světa
[09:51:05] [INFO] Všechny lokace byly zaregistrovány
Začíná tvé dobrodružství v Cisco síti...

(Stiskni CTRL+C pro ukončení)
```

## Příklad běžné lokace (Router Room)

```
━━━━━━━━━━━━ KROK 3 ━━━━━━━━━━━━

Vstupuješ do lokace: Router Room. Serverovna s racky plnými routerů. 
Všude blikají LED diody.
[09:51:19] [INFO] Hráč vstoupil do lokace: Router Room

Střetl ses s routerem zpíčenejrouter! Má pokazený RIP a routes se mažou!
[09:51:21] [INFO] Střet s nepřítelem: zpíčenejrouter (obtížnost: 3)

💡 ChatGPT říká: 'VLAN musí existovat v databázi, než ji přiřadíš!'
[09:51:22] [INFO] ChatGPT poskytl pomocnou radu

✓ Úspěšně jsi vyřešil problém s: zpíčenejrouter!
[09:51:23] [INFO] Vítězství nad: zpíčenejrouter
```

## Příklad se Switchem

```
━━━━━━━━━━━━ KROK 5 ━━━━━━━━━━━━

Vstupuješ do lokace: Switch Tower. Vysoká věž plná Cisco Catalyst switchů. 
Slyšíš hučení ventilátorů.
[09:51:33] [INFO] Hráč vstoupil do lokace: Switch Tower

Potkal jsi switch zkurvenejswitch! Spanning Tree Protocol je rozbitý a 
máš broadcast storm!
[09:51:35] [INFO] Střet s nepřítelem: zkurvenejswitch (obtížnost: 2)

✓ Úspěšně jsi vyřešil problém s: zkurvenejswitch!
[09:51:37] [INFO] Vítězství nad: zkurvenejswitch
```

## BOSS Lokace - Profesor Prokeš (Bobik)

```
━━━━━━━━━━━━ KROK 6 ━━━━━━━━━━━━

⚠️⚠️⚠️ Vstupuješ do lokace: Kancelář profesora Prokeše. 
Temná kancelář plná certifikátů CCNA, CCNP a CCIE. 
Na stole leží sada zkouškových testů. ⚠️⚠️⚠️
[09:51:40] [INFO] Hráč vstoupil do lokace: Kancelář profesora Prokeše

⚠️  POZOR! Objevil se BOSS Prokeš (Bobik)! ⚠️
Chystá se ti dát zkouškový test na BGP, MPLS a QoS najednou!
Bobik ti ukazuje diagram s AS path-prepending a říká 'A teď to nakonfiguruj!'
[09:51:42] [INFO] Střet s nepřítelem: Prokeš (Bobik) (obtížnost: 10)

✓ Úspěšně jsi vyřešil problém s: Prokeš (Bobik)!
[09:51:44] [INFO] Vítězství nad: Prokeš (Bobik)
```

## Příklad prohry

```
━━━━━━━━━━━━ KROK 8 ━━━━━━━━━━━━

⚠️⚠️⚠️ Vstupuješ do lokace: Kancelář profesora Prokeše. 
Temná kancelář plná certifikátů CCNA, CCNP a CCIE. 
Na stole leží sada zkouškových testů. ⚠️⚠️⚠️
[09:51:54] [INFO] Hráč vstoupil do lokace: Kancelář profesora Prokeše

⚠️  POZOR! Objevil se BOSS Prokeš (Bobik)! ⚠️
Chystá se ti dát zkouškový test na BGP, MPLS a QoS najednou!
Bobik ti ukazuje diagram s AS path-prepending a říká 'A teď to nakonfiguruj!'
[09:51:56] [INFO] Střet s nepřítelem: Prokeš (Bobik) (obtížnost: 10)

✗ Nepovedlo se, Prokeš (Bobik) tě porazil!
[09:51:58] [ERROR] Prohra proti: Prokeš (Bobik)
```

## Všechny možné lokace

1. **VLAN Laboratoř** - VLAN Misconfiguration
2. **IPv6 Síť** - IPv6 Routing Error
3. **Router Room** - zpíčenejrouter
4. **Switch Tower** - zkurvenejswitch
5. **Kancelář profesora Prokeše** (BOSS) - Prokeš (Bobik)

## Rady od ChatGPT (náhodné)

- "ChatGPT šeptá: 'Zkus show running-config...'"
- "ChatGPT radí: 'Možná potřebuješ no shutdown na interface?'"
- "ChatGPT připomíná: 'Nezapomněl jsi na copy running-config startup-config?'"
- "ChatGPT navrhuje: 'Co třeba debug ip routing?'"
- "ChatGPT říká: 'VLAN musí existovat v databázi, než ji přiřadíš!'"
- "ChatGPT varuje: 'Pozor na default gateway!'"

## Barevné logování (AnalyticsLibrary)

- **[INFO]** - Cyan - Běžné události
- **[WARNING]** - Yellow - Varování (obsahuje "boss", "nebezpečí")
- **[ERROR]** - Red - Chyby (obsahuje "error", "poražen")

## Poznámky

- Hra běží nekonečně, dokud ji neukončíte pomocí CTRL+C
- Každý krok trvá ~6 sekund (1.5s lokace + 1.5s nepřítel + 1s tip + 1s souboj + 3s pauza)
- ChatGPT se objevuje s 30% pravděpodobností
- Šance na výhru závisí na obtížnosti nepřítele: `šance = 100 - (obtížnost × 5)%`
  - VLAN (obtížnost 1): 95% šance na výhru
  - IPv6, Switch (obtížnost 2): 90% šance
  - Router (obtížnost 3): 85% šance
  - BOSS Prokeš (obtížnost 10): 50% šance
