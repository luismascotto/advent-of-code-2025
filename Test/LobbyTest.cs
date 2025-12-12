namespace Test;

public class LobbyTest
{
    [Fact]
    public void TestSingleBatteryPair()
    {
        var lobby = new ConsoleApp.Day3.Lobby(2, "9321283728428452622327222344422172212235228213222223255626526312275215522352294117275122222222822241");
        lobby.Solve();
        Assert.Equal("99", lobby.ResultList.First());

    }

    [Fact]
    public void TestSingleBatteryPack()
    {
        var lobby = new ConsoleApp.Day3.Lobby(2, "9321283728428452622327222344422172212235228213222223255626526312275215522352294117275122222222822241");
        lobby.Solve();
        Assert.Equal("99", lobby.ResultList.First());

    }


}