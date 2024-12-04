// See https://aka.ms/new-console-template for more information

namespace D1;

public static class Part1
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

        left.Sort();
        right.Sort();

        int totalDistance = 0;

        for (int i = 0; i < left.Count; i++)
        {
            totalDistance += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine(totalDistance);
    }
}





