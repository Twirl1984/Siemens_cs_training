namespace Hello;

public sealed class GreetingService
{
    public GreetingResult Process(string[] args)
    {
        // Keep the original T01 scope: only empty input is rejected so the app behavior stays unchanged.
        if (args.Length == 0)
        {
            return GreetingResult.Error("Bitte gib einen Namen ein!", 1);
        }

        string name = args[0];
        if (string.IsNullOrWhiteSpace(name))
        {
            return GreetingResult.Error("Der Name darf nicht leer sein.", 1);
        }

        string normalizedName = name.Trim();
        return GreetingResult.Success($"Hallo, {normalizedName}!");
    }
}

public sealed record GreetingResult(bool IsSuccess, string Message, int ExitCode)
{
    public static GreetingResult Success(string message) => new(true, message, 0);

    public static GreetingResult Error(string message, int exitCode) => new(false, message, exitCode);
}
