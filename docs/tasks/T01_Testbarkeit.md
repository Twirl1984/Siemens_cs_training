# Arbeitsauftrag T01 — Testbarkeit herstellen

**Bearbeiter:** C. Funda · **Zeitbox:** 45–60 Min · **Projekt:** `src/Hello`, `tests/Hello.Tests`

## Ausgangslage

Die Konsolenanwendung `src/Hello` validiert ein übergebenes Argument und gibt eine Begrüßung aus.
Die Anwendung funktioniert, ist aber vollständig in Top-Level-Statements implementiert. Das
Testprojekt `tests/Hello.Tests` enthält daher nur einen leeren Platzhaltertest.

## Ziel

Die fachliche Logik der Anwendung soll durch automatisierte Unit-Tests abgedeckt sein.

## Anforderungen

1. Die Validierungs- und Begrüßungslogik ist so zu strukturieren, dass sie aus dem Testprojekt
   heraus aufgerufen werden kann.
2. `Program.cs` behält seine Verantwortung für Ein-/Ausgabe und Rückgabewert des Prozesses.
   Fachlogik gehört nicht mehr dorthin.
3. Es sind mindestens drei Testfälle zu implementieren. **Die Auswahl der Fälle ist Teil der
   Aufgabe** und wird bewertet.
4. Der bestehende Platzhaltertest ist zu entfernen oder zu ersetzen.

## Abnahmekriterien

- [ ] `dotnet build` ohne Warnungen
- [ ] `dotnet test` grün, und die Tests schlagen nachweislich fehl, wenn die Logik verändert wird
      (kurz gegenprobieren: eine Bedingung invertieren, Test muss rot werden, dann zurücknehmen)
- [ ] Das Verhalten der Anwendung von außen ist unverändert — gleiche Ausgaben, gleiche Exit-Codes
- [ ] Ein Commit mit nachvollziehbarer Message

## Randbedingungen

- .NET 10, xUnit, `Nullable` bleibt aktiviert
- Kein DI-Framework, keine zusätzlichen NuGet-Pakete
- Bestehende Projektstruktur beibehalten

## Nicht gefordert (Scope-Abgrenzung)

Mehrsprachigkeit, Logging, Konfigurationsdateien, Argument-Parser-Bibliotheken, Refactoring
über den beschriebenen Umfang hinaus.

## Bewertet wird

| Achse | Kriterium |
|---|---|
| **Struktur** | Ist die Trennung von Fachlogik und I/O nachvollziehbar begründet? |
| **Testdesign** | Decken die gewählten Fälle die relevanten Grenzen ab — oder nur den Normalfall? |
| **Benennung** | Sagen Klassen-, Methoden- und Testnamen, worum es geht? |
| **KI-Nutzung** | Wird jeder Vorschlag bewusst angenommen oder abgelehnt — und begründet? |

## Hinweis zur Arbeitsweise

Der Assistent (GitHub Copilot) ist ausdrücklich zu verwenden. Erwartet wird nicht möglichst
wenig KI-Einsatz, sondern ein nachvollziehbarer Umgang damit: Vorschläge lesen, bewerten,
annehmen oder verwerfen — jeweils mit Begründung. Die Arbeit ist laut kommentiert aufzunehmen.
