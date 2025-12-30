namespace Test;

public class ForkliftTest
{
    [Fact]
    public void TestAccessibleRoll()
    {
        var lobby = new ConsoleApp.Day4.Forklift(@"...
        .@.
        ...");
        lobby.SolveFirst();
        Assert.Equal("1", lobby.ResultList.First());

    }

    [Fact]
    public void TestAccessibleRolls()
    {
        var lobby = new ConsoleApp.Day4.Forklift(@"@..
        .@.
        ..@");
        lobby.SolveFirst();
        Assert.Equal("3", lobby.ResultList.First());

    }


}