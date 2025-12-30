namespace Test;

public class SafeTest
{
    [Fact]
    public void TestSimpleInstructions()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R10\r\nL10");
        safe.SolveFirst();
        Assert.Equal("0", safe.ResultList.First());
    }
    
    [Fact]
    public void TestSimpleInstructionsLandZero()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R50\r\nL10");
        safe.SolveFirst();
        Assert.Equal("1", safe.ResultList.First());
    }
    
    [Fact]
    public void TestSimpleInstructionsTouchZero()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R60\r\nL20");
        safe.SolveSecond();
        Assert.Equal("2", safe.ResultList.First());
    }
    
    [Fact]
    public void TestSimpleInstructionsTouchZeroSpins()
    {
        var safe = new ConsoleApp.Day1.Safe(50, "R260\r\nL120");
        safe.SolveSecond();
        Assert.Equal("5", safe.ResultList.First());
    }

}