using System.Text.RegularExpressions;

namespace D4;

public class XWordCounter
{
    private readonly int _maxX;
    private readonly int _maxY;
    private readonly int _wordLenght;
    private readonly string[] _input;

    private readonly string _searchWord;
    private readonly string _searchWordReversed;
    private readonly string _searchPattern;


    public XWordCounter(string[] input, string searchWord = "MAS")
    {
        _input = input;
        _maxX = input[0].Length;
        _maxY = input.Length;
        _searchWord = searchWord;
        _wordLenght = searchWord.Length;
        _searchWordReversed = new string(searchWord.Reverse().ToArray());

        _searchPattern = $"^({_searchWord}|{_searchWordReversed})$";
    }

    public int CountWords()
    {
        int count = 0;

        string[] output = _input.ToArray();

        foreach (int y in Enumerable.Range(1, _input.Length -1 ))
        {
            foreach (int x in Enumerable.Range(1, _input[y].Length- 1))
            {
                count += IsUpRightDiagWordValid(x, y) && IsDownRightDiagWordValid(x, y) ? 1 : 0;
            }
        }

        return count;
    }


    private bool IsUpRightDiagWordValid(int x, int y)
    {
        if (y +1 >= _maxY || x -1 < -1 || y - 1 < -1 || x+1 >=_maxX )
            return false;

        var word = string.Empty;
        word += _input[y - 1][x - 1];
        word += _input[y][x];
        word += _input[y + 1][x + 1];
        return Regex.IsMatch(word, _searchPattern);
    }

    private bool IsDownRightDiagWordValid(int x, int y)
    {
        if (y + 1 >= _maxY || x - 1 < -1 || y - 1 < -1 || x + 1 >= _maxX)
            return false;

        var word = string.Empty;
        word += _input[y + 1][x - 1];
        word += _input[y][x];
        word += _input[y - 1][x + 1];

        return Regex.IsMatch(word, _searchPattern);
    }


}
