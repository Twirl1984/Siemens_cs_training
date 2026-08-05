using Hello;

namespace Hello.Tests;

public class GreetingServiceKiTests
{
    private readonly GreetingService _sut = new();

    [Theory]
    [MemberData(nameof(ProcessCases))]
    public void Process_ReturnsExpectedOutcome_ForGivenArguments(string[] args, bool expectedSuccess, int expectedExitCode, string expectedMessage)
    {
        var result = _sut.Process(args);

        Assert.Equal(expectedSuccess, result.IsSuccess);
        Assert.Equal(expectedExitCode, result.ExitCode);
        Assert.Equal(expectedMessage, result.Message);
    }

    [Fact]
    public void Process_ThrowsArgumentNullException_WhenArgsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _sut.Process(null!));
    }

    public static IEnumerable<object[]> ProcessCases()
    {
        return new[]
        {
            new object[] { Array.Empty<string>(), false, 1, "Bitte gib einen Namen ein!" },
            new object[] { new[] { "   " }, false, 1, "Der Name darf nicht leer sein." },
            new object[] { new[] { "Ada" }, true, 0, "Hallo, Ada!" },
            new object[] { new[] { "  Linus  " }, true, 0, "Hallo, Linus!" }
        };
    }
}
