
//Get args
int dayToRun = 0;
try
{
    dayToRun = int.Parse(args[0]);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during parsing day to run. {ex}");
    throw;
}


try
{

    switch (dayToRun)
    {
        case 1:
            var safeDiskDial = new ConsoleApp.Day1.Safe();

            Console.WriteLine($"Day one, dialing...:");
            safeDiskDial.Open();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Result Dial Stopped at 0: {safeDiskDial.CountLandedAtZero}");
            Console.WriteLine($"Result Dial Touched 0: {safeDiskDial.CountTouchedZero}");
            break;
        case 2:
            var giftShop = new ConsoleApp.Day2.GiftShop(2);

            Console.WriteLine($"Day Two, data processing...:");
            giftShop.IdentifyInvalidProductIds();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result list of invalidated IDs: ");
            Console.WriteLine(string.Join(", ", giftShop.InvalidProductIds.ToArray()));
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(giftShop.InvalidProductIds.Sum(id => (decimal)UInt64.Parse(id)).ToString("0"));
            Console.WriteLine();
            break;

        case 3:
            var lobby = new ConsoleApp.Day3.Lobby(12);
            Console.WriteLine($"Day Three, Batteries in the Lobby..:");
            lobby.Solve();
            Console.WriteLine("Result list of batteries jouless: ");
            for(int i=0; i< lobby.ResultList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {lobby.ResultList[i]}");
            }
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(lobby.ResultList.Sum(id => (decimal)ulong.Parse(id)).ToString("0"));
            Console.WriteLine();
            break;
        default:
            Console.WriteLine($"Day {dayToRun} not implemented yet.");
            break;

    }

}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during execution. {ex}");
}
Console.WriteLine($"Exiting in a few moments... (or press Enter key)");
Task.WaitAny([Task.Delay(300000), Task.Run(()=>Console.ReadLine())]);

