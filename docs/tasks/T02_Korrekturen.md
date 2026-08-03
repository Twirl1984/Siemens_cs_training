# Arbeitsauftrag T02 — Review-Findings abarbeiten

**Bearbeiter:** C. Funda · **Zeitbox:** 60 Min · **Vorgang:** Folge aus Review `2026-08-03_T01_Review.md`

## Ausgangslage

Die Umsetzung aus T01 ist funktionsfähig und getestet. Aus dem Review liegen fünf Findings vor.
Drei davon sind vor dem nächsten Arbeitsschritt zu beheben.

## Zu behebende Findings

### F-01 · Kulturabhängige Eingabeprüfung (Priorität: hoch)

`double.TryParse(name, out _)` wertet ohne explizite Kulturangabe gegen `CurrentCulture` aus.
Belegtes Verhalten auf de-DE: `1,5` wird abgelehnt, `NaN` wird abgelehnt, `Infinity` wird
**akzeptiert**. Auf einem Build-Server mit en-US-Locale kehrt sich das Verhalten um.

**Zu entscheiden ist zuerst, ob die Regel überhaupt bleibt.** Sie war in T01 nicht beauftragt
und ändert das Außenverhalten der Anwendung. Beide Wege sind vertretbar:

- **Regel entfällt** → Außenverhalten wie vor T01, Scope wiederhergestellt
- **Regel bleibt** → Anforderung sauber formulieren („was genau ist kein gültiger Name?"),
  kulturunabhängig implementieren, Grenzfälle testen

Die Entscheidung ist im Commit oder in einem Kommentar zu begründen. Nicht begründete
Entscheidungen gelten als offen.

### F-02 · Test dokumentiert Ist-Zustand statt Soll-Verhalten (Priorität: hoch)

`GreetingServiceTests.cs` schreibt `"Hallo,   Linus  !"` als erwartetes Ergebnis fest.
Ob führende und folgende Leerzeichen erhalten bleiben sollen, wurde nie entschieden.
Entscheidung treffen, Implementierung und Test danach ausrichten, Testname so wählen,
dass die Absicht erkennbar ist.

### F-03 · Repository nicht baubar (Priorität: hoch)

Ein frischer Klon von `c79b7e9` enthält weder `SiemensPrep.slnx` noch `src/Hello/Hello.csproj`
noch `.gitignore`. `dotnet build` scheitert mit `MSB1003`.

**Abnahme:** Ein Klon des Repositories in ein leeres Verzeichnis baut und testet ohne
zusätzliche Schritte durch.

### Nachrangig (nur bei Restzeit)

- **F-04:** `IsSuccess` und `ExitCode` halten denselben Sachverhalt doppelt.
- **F-05:** Drei der Tests sind strukturgleich und wären Kandidaten für `[Theory]` —
  planmäßig Thema an Tag 6, hier nur zur Kenntnis.

## Abnahmekriterien

- [ ] `dotnet build` ohne Warnungen, `dotnet test` grün
- [ ] Klon in leeres Verzeichnis: `dotnet build && dotnet test` läuft durch
- [ ] Für F-01 und F-02 ist die getroffene Entscheidung nachvollziehbar dokumentiert
- [ ] Der Commit ist vor dem Absetzen inhaltlich geprüft (`git status`, `git diff --staged`)

## Randbedingungen

Unverändert zu T01. Zusätzlich: **Commits werden selbst gestellt und vor dem Absetzen
geprüft.** Ein Assistent darf den Inhalt vorschlagen, die Kontrolle des Staging-Bereichs
bleibt beim Bearbeiter.

## Bewertet wird

| Achse | Kriterium |
|---|---|
| **Entscheidungsqualität** | Wird bei F-01 begründet entschieden — oder nur repariert? |
| **Verifikation** | Wird die Behebung belegt, nicht behauptet? |
| **KI-Kontrolle** | Wird geprüft, was der Assistent tatsächlich tut — insbesondere beim Commit? |
| **Erklärung** | Laufender Kommentar, hörbar. Entscheidungen begründen, nicht beschreiben. |

## Hinweis zur Arbeitsweise

**Mikrofon vor Aufnahmestart aktivieren** (QuickTime → Aufnahmemenü → Mikrofon).
Die Aufnahme aus T01 war ohne Ton und damit auf einer der drei Bewertungsachsen nicht
auswertbar.
