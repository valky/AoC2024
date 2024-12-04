using System.IO;

namespace D2;

public class ReportManager
{
    private string _path;

    public ReportManager(string path)
    {
        _path = path;

    }

    public string CalculateValidReports()
    {
        using var stremReader = new StreamReader(_path);
        var reportCount = 0;
        var falseCount = 0;

        while (!stremReader.EndOfStream)
        {
            var line = stremReader.ReadLine();

            reportCount++;
            var levels = line.Split(" ");

            var isAcendant = int.Parse(levels[1]) - int.Parse(levels[0]) > 0;
            for (int i = 1; i < levels.Length; i++)
            {
                int distance = 0;
                if (isAcendant)
                {
                   distance = int.Parse(levels[i]) - int.Parse(levels[i - 1]);
                }
                else
                {
                    distance = int.Parse(levels[i - 1]) - int.Parse(levels[i]);
                }

                if ( distance >=1 && distance <= 3)
                {
                    continue;
                }
                else
                {
                    falseCount++;
                    break;
                }
            }

        }

        return (reportCount - falseCount).ToString();
    }


    public string CalculateValidReportsWithProblemDampener()
    {
        using var stremReader = new StreamReader(_path);
        var reportCount = 0;
        var falseCount = 0;

        while (!stremReader.EndOfStream)
        {
            var line = stremReader.ReadLine();
            reportCount++;
            var levels = line.Split(" ");

            var isAcendant = int.Parse(levels[1]) - int.Parse(levels[0]) > 0;

            var issueCounter = 0;
            for (int i = 1; i < levels.Length; i++)
            {
                int distance = 0;
                if (isAcendant)
                {
                    distance = int.Parse(levels[i]) - int.Parse(levels[i - 1 ]);
                }
                else
                {
                    distance = int.Parse(levels[i - 1]) - int.Parse(levels[i]);
                }

                if (distance >= 1 && distance <= 3)
                {
                    continue;
                }
                else
                {
                    issueCounter++;
                }
            }

            if (issueCounter > 1)
            {
                Console.WriteLine("Unsafe");
                falseCount++;
            }
            else
            {
                Console.WriteLine("Safe");

            }
        }

        return (reportCount - falseCount).ToString();
    }
}
