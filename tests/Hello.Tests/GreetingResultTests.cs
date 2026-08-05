using Hello;

namespace Hello.Tests;

public class GreetingResultTests
{
    [Fact]
    public void Value_Equality()
    {
        var original = GreetingResult.Success("Hallo, Ada!");
        var twin = GreetingResult.Success("Hallo, Ada!");
        Assert.Equal(original, twin);
        Assert.Equal(original.GetHashCode(), twin.GetHashCode());
        Assert.False(object.ReferenceEquals(original, twin));

    } 
    
    [Fact]
    public void With_ReturnsNewInstance_AndLeavesOriginalUnchanged()
    {
        var original = GreetingResult.Success("Hallo, Ada!");

        var modified = original with { ExitCode = 2 };

        Assert.Equal(0, original.ExitCode);
        Assert.True(original.IsSuccess);

        Assert.Equal(2, modified.ExitCode);
        Assert.False(modified.IsSuccess);
        Assert.Equal("Hallo, Ada!", modified.Message);

        Assert.NotSame(original, modified);
    }
}
