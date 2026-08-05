using Hello;

namespace Hello.Tests;

public class GreetingServiceTests
{
    private readonly GreetingServiceChris _sut = new();

    [Fact]
    public void Process_ReturnsError_WhenNoArgumentIsProvided()
    {
        var result = _sut.Process(Array.Empty<string>());

        Assert.False(result.IsSuccess);
        Assert.Equal(1, result.ExitCode);
        Assert.Equal("Bitte gib einen Namen ein!", result.Message);
    }

    [Fact]
    public void Process_ReturnsError_WhenArgumentIsEmptyOrWhitespace()
    {
        var result = _sut.Process(new[] { "  " });

        Assert.False(result.IsSuccess);
        Assert.Equal(1, result.ExitCode);
        Assert.Equal("Der Name darf nicht leer sein.", result.Message);

    }

    [Fact]
    public void Process_ReturnsGreeting_WhenArgumentIsValid()
    {
        var result = _sut.Process(new[] { " Ada " });

        Assert.True(result.IsSuccess);
        Assert.Equal(0, result.ExitCode);
        Assert.Equal("Hallo, Ada!", result.Message);
    }
}