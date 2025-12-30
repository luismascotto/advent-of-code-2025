
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
            var safeDiskDial = new ConsoleApp.Day1.Safe(50);

            Console.WriteLine($"Day one, dialing...:");
            safeDiskDial.SolveFirst();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Result Dial Stopped at 0: {safeDiskDial.ResultList.First()}");
            
            safeDiskDial = new ConsoleApp.Day1.Safe(50);
            safeDiskDial.SolveSecond();
            Console.WriteLine();
            Console.WriteLine($"Result Dial Touched 0: {safeDiskDial.ResultList.Last()}");
            Console.WriteLine();
            break;
        case 2:
            var giftShop = new ConsoleApp.Day2.GiftShop();

            Console.WriteLine($"Day Two, Part One, data processing...:");
            giftShop.SolveFirst();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result list of invalidated IDs: ");
            Console.WriteLine(string.Join(", ", giftShop.InvalidProductIds.ToArray()));
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(giftShop.InvalidProductIds.Sum(id => (decimal)ulong.Parse(id)).ToString("0"));
            Console.WriteLine();

            giftShop = new ConsoleApp.Day2.GiftShop();

            Console.WriteLine($"Day Two, Part Two, data processing...:");
            giftShop.SolveSecond();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result list of invalidated IDs: ");
            Console.WriteLine(string.Join(", ", giftShop.InvalidProductIds.ToArray()));
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(giftShop.InvalidProductIds.Sum(id => (decimal)ulong.Parse(id)).ToString("0"));
            Console.WriteLine();
            
            break;

        case 3:
            var lobby = new ConsoleApp.Day3.Lobby();
            Console.WriteLine($"Day Three, Batteries in the Lobby..:");
            lobby.SolveFirst();
            Console.WriteLine("Result list of batteries jouless (Part One, Two Pair): ");
            for(int i=0; i< lobby.ResultList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {lobby.ResultList[i]}");
            }
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(lobby.ResultList.Sum(id => (decimal)ulong.Parse(id)).ToString("0"));
            Console.WriteLine();

            lobby = new ConsoleApp.Day3.Lobby();
            Console.WriteLine($"Day Three, Batteries in the Lobby..:");
            lobby.SolveSecond();
            Console.WriteLine("Result list of batteries jouless (Part Two, Twelve Pack): ");
            for(int i=0; i< lobby.ResultList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {lobby.ResultList[i]}");
            }
            Console.WriteLine();
            Console.Write("Sum values to answer on website: ");
            Console.WriteLine(lobby.ResultList.Sum(id => (decimal)ulong.Parse(id)).ToString("0"));
            Console.WriteLine();


            break;

        case 4:
            var forklift = new ConsoleApp.Day4.Forklift();
            Console.WriteLine($"Day Four, Forklift in the Printing Department..:");
            forklift.SolveFirst();
            Console.WriteLine("Result list of accessible rolls: ");
            Console.WriteLine(string.Join(", ", forklift.ResultList.ToArray()));
            Console.WriteLine();

            forklift = new ConsoleApp.Day4.Forklift();
            Console.WriteLine($"Day Four, Forklift in the Printing Department..:");
            forklift.SolveSecond();
            Console.WriteLine("Result list of removed rolls: ");
            Console.WriteLine(string.Join(", ", forklift.ResultList.ToArray()));
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

