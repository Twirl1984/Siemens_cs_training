namespace Hello;

public sealed record GreetingResult(string Message, int ExitCode)
{
    public bool IsSuccess => ExitCode == 0;

    public static GreetingResult Success(string message) => new(message, 0);

    public static GreetingResult Error(string message, int exitCode) => new(message, exitCode);
}
