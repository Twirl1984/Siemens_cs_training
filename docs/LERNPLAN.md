# C#/.NET-Lernplan — 17 Tage

**Zeitraum:** 03.08. – 03.09.2026 · **Umfang:** 17 Lerntage à max. 4 h
**Ziel:** Wiedereinstieg in C#/.NET mit belegbarem Fortschritt — ein wachsendes Repo statt Tutorials.

---

## 1. Zielbild

Nicht „möglichst viel C# wissen", sondern am Ende **erklären und zeigen können**, was hier
entstanden ist und warum es so gebaut ist. Der Maßstab ist nicht Syntaxumfang, sondern:

- Kann ich jede Zeile im eigenen Repo begründen?
- Kann ich Fachlogik von I/O trennen und die Trennung verteidigen?
- Kann ich einen Test schreiben, der etwas prüft — und das nachweisen?
- Kann ich mit einem KI-Assistenten arbeiten, ohne die Kontrolle abzugeben?

---

## 2. Arbeitsregeln

Diese Regeln sind aus den Erfahrungen von Tag 1 entstanden. Sie sind der wichtigste Teil
des Plans — wichtiger als die Themenliste.

### R1 · Tipp-Quote: mindestens 30 Min pro Tag ohne Assistent

**Warum:** An Tag 1 hat der Agent nahezu den gesamten C#-Code getippt. Das Ergebnis war gut,
das Review war gut — aber Syntax, die nie durch die eigenen Finger ging, ist nach elf Tagen
Urlaub weg. Und der Ausfall-Fall (Assistent nicht verfügbar) muss geübt sein, bevor er eintritt.

**Konkret:** Coding-Block 2 beginnt mit einer assistentenfreien Übung. Editor-Vorschläge aus,
Chat zu. Nachschlagen in Doku oder im eigenen Code ist erlaubt — Vervollständigen-Lassen nicht.

**Wichtig: „mindestens 30 Min ohne" heißt nicht „alles ohne".** Der Job ist KI-gestützte
Entwicklung; sie ganz auszusetzen trainiert die falsche Hälfte. Der Maßstab für die Mischung:

> **Was noch nicht beurteilt werden kann, wird selbst geschrieben.
> Was beurteilt werden kann, darf der Assistent schreiben — geprüft wird trotzdem.**

| Ab | Thema | Modus |
|---|---|---|
| sofort | Boolean-Logik, einfache Klassen, Tests im bekannten Muster | Assistent erlaubt, Ergebnis prüfen |
| T3–T4 | Collections, Datei-IO | erst selbst, dann gegenlesen lassen |
| **T5–T6** | **LINQ** | **bewusst mischen:** eigene Schleifen aus den Exercism-Lösungen (`BusyDays`, `CountForFirstDays`) selbst geschrieben → Assistent refactoren lassen → entscheiden, welche Fassung bleibt, und warum |
| ab T7 | Interfaces, DI, Architektur | Normalbetrieb: Spec → Test → implementieren lassen → prüfen |
| T14 | agentischer Workflow | voll agentisch, spec-first |
| T16 | Simulation ohne KI | komplett ohne |

### R2 · Die Gegenprobe ist Pflicht, nicht Kür

Ein grüner Testlauf beweist nichts, solange man den Test nie hat rot werden sehen. Nach jedem
neuen Test: eine Bedingung im Produktivcode invertieren, `dotnet test`, **rot sehen**,
zurücknehmen. Dreißig Sekunden.

**Warum:** Ein Test kann korrekt aussehen, korrekt benannt sein, grün sein — und trotzdem
nichts prüfen. Belegt an Tag 1: Testeingabe `"   "` fängt eine entschärfte Whitespace-Prüfung,
Testeingabe `""` nicht. Beim Lesen sind beide nicht zu unterscheiden.

### R3 · Jede KI-Entscheidung bekommt ein „weil"

Beim Annehmen und beim Ablehnen eines Vorschlags **einen Satz mit Begründung sprechen**.
Nicht „passt", sondern „ich nehme das Trimmen, weil führende Leerzeichen fast immer Tippfehler
sind und nicht Teil des Namens".

**Warum:** Wer zuschaut, kann nur bewerten, was er hört. Ein Urteil ohne Grund ist von einem
Zufallstreffer nicht unterscheidbar.

### R4 · Commits gehören dem Bearbeiter

Der Assistent darf Inhalt und Message vorschlagen. `git status` und `git diff --staged` werden
vor dem Absetzen selbst gelesen.

**Warum:** An Tag 1 hat der Agent einen Commit gesetzt, der das Repo unbaubar zurückließ —
`.slnx` und `.csproj` fehlten. Der Testlauf war trotzdem grün, weil lokal alles da war.

### R5 · Aufgaben kommen als Arbeitsauftrag, nicht als Tutorial

Jede Etappe wird als Auftrag in `docs/tasks/` formuliert: Ausgangslage, Anforderungen,
**Abnahmekriterien**, Scope-Abgrenzung. Was nicht gefordert ist, wird nicht gebaut.

**Warum:** Scope-Disziplin ist die Fähigkeit, die im Berufsalltag fehlt, wenn ein Assistent
ständig „noch eine Verbesserung" anbietet. An Tag 1 ist eine ungeplante Validierungsregel
entstanden, die das Außenverhalten der Anwendung brach.

### R6 · Störungsfreie Zeit

Coding-Blöcke laufen ohne Zurufe. Ab Tag 10 gilt das strikt — die Mock-Sessions sind wertlos,
wenn sie nicht unter realistischen Bedingungen laufen.

### R7 · Erklär-Fenster statt Dauerkommentierung

**Nicht** die ganze Session laut kommentieren, sondern nach jeder Etappe **5 Minuten bewusst
aufnehmen**: Bildschirm mit dem fertigen Stand, allein im Raum, und erklären — was gebaut,
welche Entscheidung, welche Alternative verworfen, was noch offen ist.

**Warum:** An Tag 1 sind drei Aufnahmen über 70 Minuten entstanden. Auswertbare fachliche
Äußerungen: nahezu null. Nicht aus Unwillen — im Raum lief durchgehend ein fremdes Gespräch,
und man kommentiert nicht laut, während jemand anders spricht. Fünf konzentrierte Minuten
schlagen fünfzig Minuten Hintergrundrauschen, und sie sind näher an der Interviewsituation:
Dort erklärt man auch nicht ununterbrochen, sondern an den Punkten, an denen eine Entscheidung
fällt.

**Dateiname:** `YYYY-MM-DD_thema_erklaerung.mov`

---

## 3. Umgebung

| Komponente | Stand |
|---|---|
| .NET SDK | 10.0.302 (`/usr/local/share/dotnet/sdk`) |
| Editor | VS Code 1.131 + C# Dev Kit (`ms-dotnettools.csdevkit`) |
| KI-Assistent | GitHub Copilot + Copilot Chat — **built-in in VS Code 1.131**, keine Installation nötig |
| Fallback | Claude Code (`anthropic.claude-code`) im Terminal |
| Solution | `SiemensPrep.slnx` (XML-Format ab .NET 10) |
| Repo | `~/github/Siemens_cs_training` — **außerhalb von iCloud** (Sync bricht `bin/`+`obj/`) |

**Fallback-Kette für Live-Coding:** VS Code + Copilot → Terminal + `dotnet` CLI + Claude Code
→ [dotnetfiddle.net](https://dotnetfiddle.net) im Browser.

**Kritisch:** Zwischen dem 03.09. und dem 07.09. keine System-, Homebrew- oder VS-Code-Updates.
Ein Update, das die Toolchain bricht, fällt sonst erst zum ungünstigsten Zeitpunkt auf.

---

## 4. Kalender

```
AUGUST 2026                             SEPTEMBER 2026
Mo Di Mi Do Fr  Sa So                   Mo Di Mi Do Fr  Sa So
                 1  2                       1  2  3  4   5  6
 3  4  5  6  7   8  9   ← BLOCK 1        7 ← Stichtag
10 11 12 ▓▓ ▓▓  ▓▓ ▓▓   ← Urlaub ab 13.
▓▓ ▓▓ ▓▓ ▓▓ ▓▓  ▓▓ ▓▓
24 25 26 27 28  ── ──   ← BLOCK 2
31  1  2  3 ··  ·· ··   ← 03.09. = LETZTER Lerntag
```

| Block | Zeitraum | Lerntage | Stunden |
|---|---|---|---|
| **Block 1 — Fundament** | Mo 03.08. – Mi 12.08. | 8 | 32 h |
| *Urlaub* | Do 13.08. – So 23.08. | — | 0 h |
| **Block 2 — Vertiefung** | Mo 24.08. – Do 03.09. | 9 | 36 h |
| *Funkstille* | Fr 04.09. – So 06.09. | — | 0 h |

**Der Urlaub liegt in der Mitte — elf Tage ohne C#.** Block 1 ist deshalb nicht die Hälfte des
Stoffs, sondern das Fundament, das die Pause überleben muss: Sprachkern, OOP, Collections, LINQ,
Tests. Alles Anspruchsvolle (Architektur, async, agentischer Workflow) liegt in Block 2 und ist
am Ende nur drei bis zehn Tage alt.

Tag 8 endet mit einem **Kaltstart-Paket** (`CHEATSHEET.md` + Repo-Stand), Tag 9 ist ein reiner
Reaktivierungstag ohne neuen Stoff.

---

## 5. Tagesstruktur

| Zeit | Baustein |
|---|---|
| 0:00–0:30 | Warmlauf: Recap-Karten von gestern, 20 Min Theorie zum Tagesthema |
| 0:30–2:15 | **Coding-Block 1** — Tagesziel am Projekt, mit Aufnahme, Assistent erlaubt |
| 2:15–2:30 | Pause (echt aufstehen) |
| 2:30–3:30 | **Coding-Block 2** — beginnt mit **30 Min assistentenfrei** (R1) |
| 3:30–4:00 | Abschluss: committen, 3 Recap-Karten, Video ablegen |

**Wenn ein Tag nur 2 h hergibt:** Theorie und Recap streichen, Coding-Block 1 bleibt immer.
Ein halber Coding-Tag schlägt einen ganzen Lesetag.

### Stiller Modus — wenn die Umgebung nicht mitspielt

Hitze, geteilter Raum, Lärm, Gespräche nebenan: Das kommt im August regelmäßig vor und darf
keinen Tag kosten. Für solche Tage gilt ein anderes Programm — alles, was **ohne Sprechen und
ohne tiefe Stille** funktioniert, in dieser Reihenfolge:

| Priorität | Aktivität | Warum sie trägt |
|---|---|---|
| **1** | [Exercism C#-Track](https://exercism.org/tracks/csharp) im Browser | Tippen ohne Reden, sofortiges Feedback, interviewnahe Aufgabengröße. Die beste stille Aktivität überhaupt |
| **2** | [Microsoft Learn — C#-Pfad](https://learn.microsoft.com/training/paths/csharp-first-steps/) | Interaktive Module im Browser, strukturiert, kein Setup, keine Tonspur nötig |
| **3** | Eigenen Code schriftlich kommentieren | Ersatz für das Erklär-Fenster: dieselbe Denkarbeit, nur getippt statt gesprochen. Kommt als Kommentare oder Notiz ins Repo |
| **4** | `CHEATSHEET.md` weiterschreiben | Muss ohnehin bis Tag 8 stehen, verlangt keine Konzentration am Stück |
| **5** | Videos mit Kopfhörern | Nur als Letztes — siehe Video-Falle unten. Wenn, dann mit offener IDE und Mitcodieren |

**Was im stillen Modus ausfällt:** Aufnahmen, laute Kommentierung, alles was Konzentration
über 45 Minuten am Stück braucht. Das wird nachgeholt, nicht ersetzt.

**Was NICHT passiert:** den Tag streichen. Zwei Stunden Exercism sind mehr wert als ein
ausgefallener Lerntag — und deutlich mehr als vier Stunden Videos.

---

## 6. Tagesplan

### BLOCK 1 — Fundament

**Tag 1 · Mo 03.08. — Setup + Sprachkern** ✅
Toolchain, Solution, erste Konsolenanwendung, Refactoring auf Testbarkeit, xUnit.
→ Aufträge `T01_Testbarkeit.md`, `T02_Korrekturen.md`, Review `2026-08-03_T01_Review.md`

**Tag 2 · Di 04.08. — Objektorientierung auffrischen** ← *umgebaut, siehe Abschnitt 7*
- Der eigene Code aus Tag 1 als Lehrmaterial: jede Zeile in `GreetingService.cs` erklären können
- Klasse vs. Objekt, Sichtbarkeit, Konstruktor, Feld vs. Property, statisch vs. Instanz
- `record` vs. `class` vs. `struct` — und **wann welches**
- **Nullable Reference Types** (`string?`, `?.`, `??`) — moderner C#-Standard
- R1: `GreetingResult` von Hand nachbauen, ohne Assistent

**Tag 3 · Mi 05.08. — Collections**
- `List<T>`, `Dictionary<K,V>`, `HashSet<T>`, Array — und **warum** welche (O(1)-Lookup vs. Reihenfolge)
- `IEnumerable<T>` vs. `List<T>` in Signaturen: Rückgabe allgemein, Parameter spezifisch
- `TagLint` startet: Tags in Liste halten, Adress-Lookup über Dictionary
- R1: eine Collection-Übung ohne Assistent

**Tag 4 · Do 06.08. — Dateien + Fehlerbehandlung**
- `File.ReadAllLines` vs. `File.ReadLines` (streamend — der Unterschied zählt)
- CSV parsen; `using` / `IDisposable`; `try`/`catch`/`finally`
- Exceptions: wann werfen, wann fangen, **warum niemals `catch (Exception)` stumm schlucken**
- `TagLint`: `TagTableReader` liest eine CSV mit ~30 Testzeilen

**Tag 5 · Fr 07.08. — LINQ Teil 1**
- `Where`, `Select`, `OrderBy`, `First`/`FirstOrDefault`, `Any`, `All`, `Count`
- **Deferred Execution** — LINQ läuft erst bei `ToList()`/`foreach`
- `TagLint`: erste Auswertungen

**Tag 6 · Mo 10.08. — LINQ Teil 2 + xUnit-Tiefe**
- `GroupBy`, `SelectMany`, `ToDictionary`, `Sum`/`Average`/`Max`
- `[Theory]` + `[InlineData]` / `[MemberData]`, `Assert.Throws`
- `TagLint`: `DuplicateAddressRule` per `GroupBy` + parametrisierte Tests
- R2 vertiefen: Was fängt ein Test, was nicht?

**Tag 7 · Di 11.08. — Interfaces, DI, Clean Code**
- `interface` vs. `abstract class`; `IRule` einführen; Konstruktor-Injection **ohne Framework**
- Refactoring: sprechende Namen, kleine Methoden, keine Magic Numbers
- `TagLint`: `NamingRule` + `RuleEngine` mit injizierten Regeln

**Tag 8 · Mi 12.08. — XML, CI, Kaltstart-Paket**
- `XDocument`/LINQ-to-XML: TIA-Openness-Export-Look nachbauen und einlesen
- GitHub Actions: `.github/workflows/ci.yml` mit `dotnet build` + `dotnet test`
- **`CHEATSHEET.md` selbst formulieren** (keine Kopie) + `README.md` „Stand am 12.08."
- Ziel: ein Repo, in das man nach elf Tagen zurückkehren kann, ohne zu suchen

### URLAUB · Do 13.08. – So 23.08.
**Pflicht: nichts.** Optional in der zweiten Hälfte 2× 20 Min Video, passiv. Wenn es sich nach
Arbeit anfühlt: lassen.

### BLOCK 2 — Vertiefung

**Tag 9 · Mo 24.08. — Reaktivierung (kein neuer Stoff)**
- `CHEATSHEET.md` durchgehen, Repo bauen, Tests laufen lassen
- Kata **ohne Assistent**: eine bestehende Regel aus dem Kopf nachbauen
- Das ist eine Messung, kein Test. Wiedererlernen geht drei- bis viermal schneller als Erstlernen.

**Tag 10 · Di 25.08. — async/await + moderne Sprachfeatures**
- `Task`, `async`/`await`; **warum kein `.Result`/`.Wait()`** (Deadlock-Falle)
- Pattern Matching, `switch`-Expressions, Collection-Expressions
- `TagLint`: File-IO auf `async` umstellen

**Tag 11 · Mi 26.08. — Architektur + SOLID am eigenen Code**
- `UnusedTagRule`, `IReporter` einführen (Konsole + JSON)
- Jedes SOLID-Prinzip an **einer konkreten Stelle im eigenen Repo** benennen können

**Tag 12 · Do 27.08. — Test-Tiefe**
- Unit / Integration / System im C#-Vokabular
- Testbarkeit durch DI; handgeschriebene Fakes vs. Moq (Konzept reicht)
- Coverage anschauen, aber **nicht** zum Ziel machen

**Tag 13 · Fr 28.08. — Supply Chain + Compliance-Feature**
- `dotnet list package --vulnerable --format json` parsen (`System.Text.Json`), Report ausgeben
- SBOM-Grundlagen, transitive NuGet-Abhängigkeiten

**Tag 14 · Mo 31.08. — Agentischen Workflow scharfstellen**
- `.github/copilot-instructions.md` + `CLAUDE.md` fürs Repo schreiben
- `docs/specs/` anlegen und **ein Feature komplett spec-first bauen**
- Copilot und Claude Code am selben Problem vergleichen

**Tag 15 · Di 01.09. — Simulation 1 (mit Assistent)**
- 60 Min unbekannte Aufgabe, Timer, laut denken, Nachfragen mitten im Tippen
- Copilot-Kontingent verifizieren

**Tag 16 · Mi 02.09. — Simulation 2 (OHNE Assistent)**
- Dieselbe Aufgabenart, Copilot komplett aus
- C#-Fragenkatalog **mündlich** durchgehen

**Tag 17 · Do 03.09. — Generalprobe + Technik-Check**
- 90 Min Vollsimulation im echten Setup
- Repo aufräumen, **leeres Startprojekt** `src/Interview` anlegen
- Danach: keine Updates mehr

---

## 7. OOP-Auffrischung — der eigene Code als Lehrbuch

Objektorientierung ist eingerostet. Der schnellste Weg zurück führt **nicht** über ein Tutorial,
sondern über 31 Zeilen, die bereits im Repo liegen. `src/Hello/GreetingService.cs` enthält
praktisch den gesamten OOP-Grundkurs:

| Zeile | Konstrukt | Was zu verstehen ist |
|---|---|---|
| `namespace Hello;` | Namensraum | Wozu Namensräume, was passiert ohne |
| `public sealed class GreetingService` | Klasse, Sichtbarkeit, `sealed` | Klasse = Bauplan, Objekt = Exemplar. Was heißt `public`? Warum `sealed`? |
| `public GreetingResult Process(string[] args)` | Methode | Rückgabetyp, Parameter, Signatur |
| `public sealed record GreetingResult(string Message, int ExitCode)` | Record + Primärkonstruktor | Warum `record` statt `class`? Was ist Wertgleichheit? |
| `public bool IsSuccess => ExitCode == 0;` | berechnete Property | Property vs. Feld vs. Methode — wann was |
| `public static GreetingResult Success(...) => new(...)` | statische Factory-Methode | `static` = gehört zur Klasse, nicht zum Objekt. Warum eine Factory? |
| `private readonly GreetingService _sut = new();` *(Test)* | Feld, `readonly`, Instanziierung | Wann wird das Objekt erzeugt? Wie oft? |

**Übung für Tag 2 (60–90 Min, ohne Assistent):**

1. Jede Zeile laut erklären — nicht „was steht da", sondern „warum steht das da"
2. Ein zweites Werteobjekt von Hand bauen (z. B. `ValidationResult` mit gleicher Struktur)
3. Bewusst einmal falsch machen: `sealed` entfernen und ableiten, `static` weglassen und sehen
   was der Compiler sagt. **Compilerfehler sind die schnellste OOP-Lehrerin.**

### Die konkrete Frageliste aus der Kata (03.08.)

Beim Nachbauen von Hand sind drei Abweichungen zum Original entstanden. Jede davon ist eine
offene Frage — und damit der Lehrplan für Tag 2:

| Abweichung | Frage dahinter |
|---|---|
| `GreetingResult` in **eigene Datei** gelegt (Original: unten in `GreetingService.cs`) | Wann ein Typ pro Datei, wann mehrere? Was ist C#-Konvention und warum? *(Diese Entscheidung war besser als das Original.)* |
| `public class` statt `public sealed class` | Was macht `sealed`? Was kostet es, was bringt es? Wollte ich es weglassen oder habe ich es vergessen? |
| Testfall `" Ada "` prüft **gültig und Trimmen zugleich**, der Testname nennt nur das erste | Was prüft ein Test — eine Sache oder mehrere? Woran erkenne ich beim roten Test, was gebrochen ist? |

Dazu aus dem Build-Bruch derselben Session:

| Problem | Frage dahinter |
|---|---|
| Zwei Implementierungen im selben Namensraum → 7 Compilerfehler | Wie funktionieren Namensräume? Was kollidiert womit? Wie hält man Varianten sauber nebeneinander? |

**Was NICHT nötig ist:** Vererbungshierarchien, abstrakte Basisklassen, Polymorphie über
mehrere Ebenen. Modernes C# löst das meiste über Komposition und Interfaces — das kommt an
Tag 7 und reicht völlig.

---

## 8. Übungsprojekt: `TagLint`

Ein Linter für TIA-Tag-Tabellen. TIA Openness exportiert SPS-Variablen als XML; das Tool liest
den Export, prüft ihn gegen Namens- und Qualitätsregeln und gibt einen Report aus. Klein,
erweiterbar, domänennah — und Trainingsgerät für jedes Thema des Plans.

```
Siemens_cs_training/
├── SiemensPrep.slnx
├── CHEATSHEET.md                   # T8
├── .github/workflows/ci.yml        # T8
├── .github/copilot-instructions.md # T14
├── docs/
│   ├── LERNPLAN.md                 # dieses Dokument
│   ├── tasks/                      # Arbeitsaufträge (R5)
│   └── reviews/                    # Session-Reviews
├── _recordings/                    # in .gitignore
├── src/
│   ├── Hello/                      # T1 ✅
│   └── TagLint/
│       ├── Model/Tag.cs                    # T2
│       ├── Parsing/TagTableReader.cs       # T4 CSV → T8 XML
│       ├── Rules/IRule.cs                  # T7
│       ├── Rules/NamingRule.cs             # T7
│       ├── Rules/DuplicateAddressRule.cs   # T6
│       ├── Rules/UnusedTagRule.cs          # T11
│       ├── Reporting/IReporter.cs          # T11
│       └── Program.cs
└── tests/TagLint.Tests/            # ab T6 mitwachsend
```

Das Interface, um das herum Block 2 gebaut wird:

```csharp
public interface IRule
{
    string Id { get; }
    IEnumerable<Finding> Check(IReadOnlyList<Tag> tags);
}
```

Jede Regel eine eigene Klasse, `RuleEngine` bekommt sie per Konstruktor injiziert — DI ohne
Framework reicht und lässt sich in zwei Sätzen erklären.

---

## 9. Der KI-Workflow

Der Code darf solide sein; **der Workflow muss belastbar sein.**

1. **Spec zuerst.** Vor der ersten Zeile Code: 3–6 Zeilen — Input, Output, Edge Cases.
2. **Test zuerst.** Den Testfall aus der Spec generieren lassen — und den Test *lesen*,
   bevor die Implementierung kommt. Ein roter Test ist ein guter Test.
3. **Implementieren lassen, dann prüfen.** Vorschlag annehmen **oder ablehnen — beides mit
   Begründung** (R3).
4. **Review-Runde.** „Welche Edge Cases fehlen? Was passiert bei leerer Datei, bei null,
   bei 500 MB?"
5. **Refactor.** Erst wenn grün.
6. **Gegenprobe** (R2) und **eigener Commit** (R4).

### Die zwei Fallen, die an Tag 1 zugeschnappt haben

**Falle 1 — „Evidence" ohne Substanz.**
Auf die Anfrage `test` meldete der Assistent: *„Evidence: 1 test ran, 1 passed."* Der einzige
Test hatte einen leeren Körper. Ein Test ohne Assertion besteht immer.

**Falle 2 — „Verifiziert" mit zu enger Frage.**
Der Agent meldete *„Verifiziert: 5 Tests erfolgreich"* und committete. Der Commit ließ ein
Repo zurück, das sich nicht klonen und bauen ließ — `.slnx` und `.csproj` fehlten. Lokal war
alles grün, weil die Dateien lokal existierten.

**Beide Aussagen waren wörtlich wahr und trotzdem irreführend**, weil sie eine engere Frage
beantworteten als die, auf die es ankam. Daraus folgen R2 und R4.

### Copilot oder Claude Code?

Copilot ist im Editor stark bei Completion und kleinen Diffs. Claude Code passt, wenn eine
Änderung mehrere Dateien betrifft und ein Plan davor gehört. Die interessantere Frage ist,
wo Assistenz aufhört und ein Agent anfängt.

---

## 10. Video-Feedback-Loop

Aufnehmen, während gearbeitet und **laut kommentiert** wird.

- **QuickTime Player** → *Ablage → Neue Bildschirmaufnahme* → **Mikrofon im Aufnahmemenü
  aktivieren.** Muss pro Aufnahme neu gesetzt werden. Die erste Aufnahme an Tag 1 war ohne Ton
  und damit auf einer von drei Achsen nicht auswertbar.
- Ablage in `_recordings/` (in `.gitignore`)
- Dateiname `YYYY-MM-DD_thema.mov`, Länge 10–20 Min aus Coding-Block 1

**Bewertungsraster:**

| Achse | Worauf geschaut wird |
|---|---|
| **Code** | Benennung, Methodengröße, Edge Cases, Null-Handling, Testabdeckung, idiomatisches C# |
| **Erklärung** | Laut gedacht oder still getippt? Entscheidungen begründet oder nur beschrieben? |
| **KI-Nutzung** | Jeder Vorschlag bewusst angenommen/abgelehnt? Diff gelesen? Spec vor dem Code? |

Ab Tag 14 ohne Schnitt und mit Timer. Ab Tag 15 mit Störungen (Nachfrage mitten im Tippen).

---

## 11. Lernquellen

| Quelle | Wofür | Wann |
|---|---|---|
| [Microsoft Learn: C#](https://learn.microsoft.com/dotnet/csharp/) | Referenz + Grundlagen | T1–T7, zum Nachschlagen |
| [Exercism C#-Track](https://exercism.org/tracks/csharp) | Kleine Aufgaben, sehr interviewnah — **Concept Exercises** decken OOP systematisch ab | T2–T6, im Coding-Block 2 **und im stillen Modus** |
| **Nick Chapsas** (YouTube) | Modernes, idiomatisches C# | T2, T5, T10 |
| **Milan Jovanović** (YouTube) | Clean Architecture, Testing, DI | T7, T11, T12 |
| [TIA Openness Handbuch (PDF)](https://cache.industry.siemens.com/dl/files/886/109826886/att_1163875/v1/TIAPortalOpenness_enUS_en-US.pdf) | Domänenwissen | T8 |

**Video-Falle:** Videos schauen fühlt sich nach Fortschritt an, ist aber keiner. Deshalb
20 Min Theorie zu 2:45 h Tippen — **Verhältnis 1:8.**

---

## 12. Fortschritt

| Tag | Datum | Thema | Status |
|---|---|---|---|
| 1 | 03.08. | Setup, Sprachkern, Testbarkeit | ✅ T01 + T02 abgenommen, Kata von Hand nachgebaut |
| 2 | 04.08. | OOP-Auffrischung, `record`, Nullable | offen |
| 3 | 05.08. | Collections | offen |
| 4 | 06.08. | Dateien, Fehlerbehandlung | offen |
| 5 | 07.08. | LINQ 1 | offen |
| 6 | 10.08. | LINQ 2, xUnit-Tiefe | offen |
| 7 | 11.08. | Interfaces, DI, Clean Code | offen |
| 8 | 12.08. | XML, CI, Kaltstart-Paket | offen |
| 9 | 24.08. | Reaktivierung | offen |
| 10 | 25.08. | async/await | offen |
| 11 | 26.08. | Architektur, SOLID | offen |
| 12 | 27.08. | Test-Tiefe | offen |
| 13 | 28.08. | Supply Chain | offen |
| 14 | 31.08. | Agentischer Workflow | offen |
| 15 | 01.09. | Simulation 1 | offen |
| 16 | 02.09. | Simulation 2 (ohne KI) | offen |
| 17 | 03.09. | Generalprobe | offen |
