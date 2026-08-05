# Arbeitsauftrag T03 — Werttypen und Nullable am eigenen Code

**Bearbeiter:** C. Funda · **Zeitbox:** 90 Min · **Lerntag:** 2 (04.08.)
**Vorgang:** Theorieblock `record`/`class`/`struct` + Nullable Reference Types ist absolviert.
Dieser Auftrag prüft, ob das Gesehene am eigenen Code trägt.

## Ausgangslage

`src/Hello/GreetingResult.cs` ist ein `sealed record` mit Primärkonstruktor, berechneter
Property und zwei statischen Factory-Methoden — vier der fünf Konstrukte aus dem Video stehen
bereits im Repo. Behauptet wird bisher nur, dass `record` Wertgleichheit liefert; **belegt
ist es nicht.** Kein Test im Repo prüft das Verhalten von `GreetingResult` selbst.

`<Nullable>enable</Nullable>` ist in `src/Hello/Hello.csproj` gesetzt. Ob der Schalter im
Testprojekt ebenfalls greift, ist ungeprüft.

## Anforderungen

### A1 · Wertgleichheit belegen — **ohne Assistent** (Editor-Vorschläge aus, Chat zu)

Neue Datei `tests/Hello.Tests/GreetingResultTests.cs`. Zu belegen ist:

- Zwei unabhängig erzeugte `GreetingResult` mit identischem Inhalt sind gleich (`==`, `.Equals`)
- Ihre Hashcodes stimmen überein
- `ReferenceEquals` liefert trotzdem `false` — es sind zwei Objekte

**Gegenprobe (R2), Pflicht:** `record` in `GreetingResult.cs` durch `class` ersetzen,
`dotnet test`, **rot sehen**, zurücknehmen. Welche Assertion fällt zuerst? Notieren.

### A2 · Unveränderlichkeit und `with`

Ein Test, der zeigt: `original with { ExitCode = 2 }` liefert ein neues Objekt, das Original
bleibt unangetastet. Zu beantworten (mündlich, Erklär-Fenster): Warum lässt sich
`result.Message = "..."` nicht zuweisen, obwohl kein `readonly` im Code steht?

### A3 · `struct`: der Unterschied, der zählt — **ohne Assistent**

In einer Wegwerf-Datei `src/Hello/Scratch.cs` einen `readonly record struct GreetingValue`
mit denselben zwei Komponenten anlegen und zwei Dinge auslösen:

1. `GreetingValue v = null;` → Compiler ablehnen lassen. **Fehlernummer notieren.**
   Gegenprobe: Warum geht `GreetingResult r = null;` (mit welcher Reaktion des Compilers)?
2. Eine Variable einer zweiten zuweisen, dann die zweite per `with` ändern — was passiert
   mit der ersten, und warum ist das bei `class` anders?

`Scratch.cs` wird am Ende **gelöscht**. Das Ergebnis gehört in die Recap-Karte, nicht ins Repo.



### A5 · Nur bei Restzeit — Namensdoppelung auflösen

`GreetingServiceChris` (Handarbeit) und `GreetingService` (KI-Variante) sind inhaltlich
identisch; `Program.cs` benutzt die KI-Variante, die Handarbeit ist toter Code. Entscheiden,
welche bleibt, und die Entscheidung begründen. Wenn die Zeit nicht reicht: stehen lassen,
kommt als T04.

## Abnahmekriterien

- [ ] `dotnet build` ohne Warnungen, `dotnet test` grün
- [ ] Gegenprobe aus A1 wurde **rot gesehen**, nicht nur durchdacht
- [ ] Fehler-/Warnungsnummern aus A3 und A4 stehen in der Recap-Karte von heute
- [ ] `src/Hello/Scratch.cs` ist gelöscht, `git status` ist sauber
- [ ] Für A4.3 ist die Entscheidung nachvollziehbar dokumentiert
- [ ] Commit selbst gestellt, `git diff --staged` vorher gelesen (R4)

## Scope-Abgrenzung

**Nicht** Gegenstand dieses Auftrags: Vererbung und Interfaces (Tag 7), Umbau der bestehenden
Tests auf `[Theory]` (Tag 6), LINQ (Tag 5), Start von `TagLint` (Tag 3). Was nicht gefordert
ist, wird nicht gebaut — auch nicht, wenn der Assistent es anbietet.

## Bewertet wird

| Achse | Kriterium |
|---|---|
| **Beleg statt Behauptung** | Wird Wertgleichheit gezeigt oder nur behauptet? Wurde der Test rot gesehen? |
| **Compilerfehler lesen** | Werden Fehlernummer und Ursache benannt — oder nur die Zeile repariert? |
| **Entscheidungsqualität** | A4.3: begründete Entscheidung oder Reflex? |
| **Scope-Disziplin** | Bleibt `Scratch.cs` draußen? Wird A5 bei Zeitmangel wirklich vertagt? |
