using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public static class ProcessSplit
{
    
    private static int DialPosition;

    public static int Start_SplitStringArray_ProcessingByString(string input)
    {
        var instructions = input.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //Console.WriteLine($"Total of {instructions.} instructions");
        int countZeros = 0;
        DialPosition = 50;
        foreach (var moveTo in instructions)
        {
            countZeros += ProcessByString(moveTo);
        }
        return countZeros;
    }

    public static int Start_SpanSplit_ToString_ProcessByString(ReadOnlySpan<char> input)
    {
        var instructions = input.Split("\r\n");
        //Console.WriteLine($"Total of {instructions.} instructions");
        int countZeros = 0;
        DialPosition = 50;
        foreach (var moveTo in instructions)
        {
            countZeros += ProcessByString(input[moveTo].ToString());
        }
        return countZeros;
    }
    
    public static int Start_SpanSplit_Range_ProcessByPrimitives(ReadOnlySpan<char> input)
    {
        var instructions = input.Split("\r\n");
        //Console.WriteLine($"Total of {instructions.} instructions");
        int countZeros = 0;
        DialPosition = 50;
        foreach (var moveTo in instructions)
        {
            countZeros += ProcessByPrimitives(input[moveTo.Start], int.Parse(input[(moveTo.Start.Value + 1)..moveTo.End]));
        }
        return countZeros;
    }
    
    private static int ProcessByString(string instruction)
    {
        char direction = instruction[0];
        int clicks = int.Parse(instruction[1..]);
        return ProcessByPrimitives(direction, clicks);
    }
    private static int ProcessByPrimitives(char direction, int clicks)
    {
        //var direction = clicks[0];
        // More than 100 moves wrap around
        //var clicks = int.Parse(clicks[1..]) % 100;
        int netClicks = clicks % 100;
        if (direction == 'L')
        {
            // X moves tothe left is equivalent to (100 - X) moves to the right to ending position        
            //Console.Write($" AM:{clicks}, ");
            DialPosition += (100 - netClicks);
        }
        else if (direction == 'R')
        {
            DialPosition += netClicks;
        }
        //Console.Write($"{clicks}, ");
        DialPosition %= 100;
        //Console.Write($"{clicks}, Dial at {DialPosition}!\n");
        if (DialPosition == 0)
        {
            return 1;
        }
        return 0;
    }

}

