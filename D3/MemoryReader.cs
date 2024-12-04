using System;
using System.Text.RegularExpressions;

namespace D3;

public class MemoryReader
{
    private readonly string _path;

    public MemoryReader(string path)
    {
        _path = path;
    }

    public List<string> ReadMulFromCorruptMemory()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";

        string[] lines = File.ReadAllLines(_path);

        List<string> allMatches = new List<string>();
        foreach (Match match in Regex.Matches(lines[0], pattern))
        {
            allMatches.Add(match.Value);
        }
        return allMatches;
    }


    public List<string> ReadMulWithEnableFromCorruptMemory()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";

        string[] lines = File.ReadAllLines(_path);

        var splitlines = lines[0].Split("don't()");

        List<string> allMatches = new List<string>();
        for (int i = 0; i < splitlines.Length; i++)
        {
            var enalbed = "";
            if (i == 0)
            {
                enalbed = splitlines[i];
            }
            else
            {
                var index = splitlines[i].IndexOf("do()");
                if (index >=0)
                    enalbed = splitlines[i].Substring(index);
            }

            foreach (Match match in Regex.Matches(enalbed, pattern))
            {
                allMatches.Add(match.Value);
            }
        }

        return allMatches;
    }
}
