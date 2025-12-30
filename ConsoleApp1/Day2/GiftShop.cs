using System;


namespace ConsoleApp.Day2;

public class GiftShop : AoC, IAoC
{
    const string DefaultInput = @"824-1475,967620-1012917,2727216511-2727316897,56345-141494,8811120-8999774,5727326-5922513,935306-961989,76751455-76787170,723458-849157,144648-162230,1597-3207,326085-472746,14-34,66-132,9453977670-9454023729,959903262-960027272,17168-26699,190-332,3351-5602,1-11,371280315-371448887,6252062-6312899,9696887156-9697040132,37-58,32770-52161,6443650762-6443689882,473092-582157,3309726-3347079,852735-912990,8294840594-8294926063,3773964-3884030,7718304-7809359,601947-677833,3434304207-3434405118,449-673,64525269-64702774,31545468-31784543,184451-308951,5771-11485";


    public List<string> InvalidProductIds { get; private set; }

    //private string Input { get; set; }
    private int Method { get; set; }


    public GiftShop(string input = "") : base(string.IsNullOrEmpty(input) ? DefaultInput : input)
    {
        InvalidProductIds = [];
    }

    public void SolveFirst()
    {
        Method = 1;
        Solve();
    }
    public void SolveSecond()
    {
        Method = 2;
        Solve();
    }
    private void Solve()
    {
        var spanEnumIdRanges = Input.AsSpan().Split(",");

        Console.WriteLine($"Total of {spanEnumIdRanges.Source.Count('-')} product id ranges");

        foreach (var rngIdRange in spanEnumIdRanges)
        {
            var spanEnumIdRangeParts = spanEnumIdRanges.Source[rngIdRange].Split("-");
            int temp = 0;
            foreach (var rngId in spanEnumIdRangeParts)
            {
                Console.Write($"{spanEnumIdRangeParts.Source[rngId]}");
                if (temp == 0)
                {
                    Console.Write("-");
                }
                temp++;
            }
            Console.WriteLine();

            UInt64 firstId = 0;
            UInt64 lastId = 0;
            int countParts = 0;
            int firstIdLen = 0;
            int lastIdLen = 0;
            foreach (var rngId in spanEnumIdRangeParts)
            {
                // Validations for each id part
                if (spanEnumIdRangeParts.Source[rngId.Start] is < '1' or > '9')
                {
                    throw new ArgumentException($"malformed id [{spanEnumIdRangeParts.Source[rngId]}]");
                }
                if (!UInt64.TryParse(spanEnumIdRangeParts.Source[rngId], out UInt64 parsedId) || parsedId <= 0)
                {
                    throw new ArgumentException($"parse id from serie [{spanEnumIdRangeParts.Source[rngId]}]");
                }

                switch (++countParts)
                {
                    case 1:
                        firstId = parsedId;
                        firstIdLen = spanEnumIdRangeParts.Source[rngId].Length;
                        break;
                    case 2:
                        lastId = parsedId;
                        lastIdLen = spanEnumIdRangeParts.Source[rngId].Length;
                        break;
                }
            }
            // Validations between parts
            if (countParts is not (1 or 2))
            {
                throw new ArgumentException($"parts count invalid [{countParts}]");
            }
            // Value 0 is already checked above when parsing each id part
            if (lastId < firstId)
            {
                throw new ArgumentException($"last id [{lastId}] less than first id [{firstId}]");
            }
            if (Method == 1)
            {
                // Silly Patterns (any pattern repeated TWO times) only occurs with EVEN id sizes.
                // No need to search when both ids have EQUAL and ODD lengths.
                if (firstIdLen == lastIdLen && (firstIdLen % 2 == 1))
                {
                    continue;
                }
                //+++ Otimization only for LENGTH difference equals 1 (e.g., 6-20, or 90-114) ++++++
                // If firstIdLen is ODD, set firstId to "10^(firstIdLen)" (next value for lentgh EVEN)
                // the next EVEN length.
                // Oposite case (firstIdLen EVEN and lastIdLen ODD) descrease lastId to the previous EVEN length.
                if (lastIdLen == firstIdLen + 1)
                {
                    if (firstIdLen % 2 == 1)
                    {
                        firstId = (UInt64)Math.Pow(10, firstIdLen);
                    }
                    else
                    {
                        lastId = (UInt64)Math.Pow(10, firstIdLen) - 1;
                    }
                }
            }

            ValidateSerieByFirstAndLastIds(firstId, lastId);
        }
    }

    private void ValidateSerieByFirstAndLastIds(UInt64 firstId, UInt64 lastId)
    {

        for (UInt64 id = firstId; id <= lastId; id++)
        {
            if (IdContainsSillyPattern(id))
            {
                InvalidProductIds.Add(id.ToString());
            }
        }
    }

    private bool IdContainsSillyPattern(UInt64 id)
    {
        Span<char> numberStr = stackalloc char[32];
        if (!id.TryFormat(numberStr[..], out int len))
        {
            return false;
        }
        numberStr = numberStr[..len];

        // EVEN PRIME can only contains series of 1 repeated digit
        if (len is 3 or 5 or 7)
        {
            for (int i = 1; i < len; i++)
            {
                if (numberStr[0] != numberStr[i])
                {
                    return false;
                }
            }
            return true;
        }

        //Standard Half/Half comparison
        if (numberStr[..(len / 2)].SequenceEqual(numberStr[(len / 2)..]))
        {
            return true;
        }
        if (Method == 1)
        {
            return false;
        }
        try
        {
            for (int div = 3; div <= len / 2; div++)
            {
                if (len % div == 0)
                {
                    int partLen = len / div;
                    bool allPartsEqual = true;
                    for (int part = 1; part < div; part++)
                    {
                        if (!numberStr[..partLen].SequenceEqual(numberStr[(part * partLen)..((part + 1) * partLen)]))
                        {
                            allPartsEqual = false;
                            break;
                        }
                    }
                    if (allPartsEqual)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"id={id} - {ex.Message}");
            return false;
        }
    }
}
