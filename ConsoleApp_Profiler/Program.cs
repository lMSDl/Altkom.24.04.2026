using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        var data = GenerateData(1_000_000);

        var stopwatch = Stopwatch.StartNew();

        var result = ProcessData(data);

        stopwatch.Stop();
        Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Result: {result}");
    }

    static List<int> GenerateData(int size)
    {
        var rand = new Random();
        return Enumerable.Range(0, size)
            .Select(_ => rand.Next(1, 1000))
            .ToList();
    }

    static int ProcessData(List<int> data)
    {
        int count = 0;
        int max = int.MinValue;
        int sum = 0;

        foreach (var value in data)
        {
            if (value % 2 == 0 && value > 500)
            {
                count++;
                sum += value;
                if (value > max)
                    max = value;
            }
        }

        return count + max + sum;
    }
}