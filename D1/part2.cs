// See https://aka.ms/new-console-template for more information

using System;

namespace D1;

public static class Part2
{
    public static void Execute()
    {
        using var stremReader = new StreamReader("real_inputs.txt");

        List<int> left = new List<int>();
        List<int> right = new List<int>();
        while (!stremReader.EndOfStream)
        {
            var lineinput = stremReader.ReadLine();
            var line = lineinput.Split("   ");
            left.Add(int.Parse(line[0]));
            right.Add(int.Parse(line[1]));
        }

        var frequencies = new Dictionary<int, int>();
        foreach (var value in right)
        {
            if (!frequencies.ContainsKey(value))
                frequencies[value] = 0;
            frequencies[value]++;
        }

        int similiarityScore = 0;
        foreach (var leftNum in left)
        {
            if (frequencies.TryGetValue(leftNum, out int frequency))
            {
                similiarityScore += leftNum * frequency;
            }
        }

        Console.WriteLine(similiarityScore);
    }
}





