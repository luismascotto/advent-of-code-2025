namespace Test;

public class GiftShopTest
{
    [Fact]
    public void TestANumberExtended()
    {
        var gift = new ConsoleApp.Day2.GiftShop("371280315-371448887", 2);

        gift.IdentifyInvalidProductIds();

        Assert.True(gift.InvalidProductIds.Any());
    }
    
}