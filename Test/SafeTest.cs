namespace Test;

public class SafeTest
{
    [Fact]
    public void TestSimpleInstructions()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R10\r\nL10");
        safe.Open();
        Assert.Equal(0, safe.CountLandedAtZero);
        Assert.Equal(0, safe.CountTouchedZero);
    }
    
    [Fact]
    public void TestSimpleInstructionsLandZero()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R50\r\nL10");
        safe.Open();
        Assert.Equal(1, safe.CountLandedAtZero);
        Assert.Equal(1, safe.CountTouchedZero);
    }
    
    [Fact]
    public void TestSimpleInstructionsTouchZero()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R60\r\nL20");
        safe.Open();
        Assert.Equal(0, safe.CountLandedAtZero);
        Assert.Equal(2, safe.CountTouchedZero);
    }
    
    [Fact]
    public void TestSimpleInstructionsTouchZeroSpins()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R260\r\nL120");
        safe.Open();
        Assert.Equal(0, safe.CountLandedAtZero);
        Assert.Equal(5, safe.CountTouchedZero);
    }

}