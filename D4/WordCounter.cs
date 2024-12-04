using System.Text.RegularExpressions;

namespace D4;

public class WordCounter
{
    private readonly int _maxX;
    private readonly int _maxY;
    private readonly int _wordLenght;
    private readonly string[] _input;

    private readonly string _searchWord;
    private readonly string _searchWordReversed;
    private readonly string _searchPattern;


    public WordCounter(string[] input, string searchWord)
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

        foreach (int y in Enumerable.Range(0, _input.Length))
        {
            foreach (int x in Enumerable.Range(0, _input[y].Length))
            {
                count += IsRightWordValid(x, y) ? 1 : 0;
                count += IsDownWordValid(x, y) ? 1 : 0;
                count += IsLeftDiagWordValid(x, y) ? 1 : 0;
                count += IsRightDiagWordValid(x, y) ? 1 : 0;
            }
        }

        return count;
    }


    private bool IsRightWordValid(int x, int y)
    {
        if (x + _wordLenght > _maxX)
            return false;
        return Regex.IsMatch(_input[y].Substring(x, _searchWord.Length), _searchPattern);
    }

    private bool IsDownWordValid(int x, int y)
    {
        if (y + _wordLenght > _maxY)
            return false;

        var word = string.Empty;

        for (int i = 0; i < _wordLenght; i++)
        {
            word += _input[y + i][x];
        }
        return Regex.IsMatch(word, _searchPattern);
    }

    private bool IsRightDiagWordValid(int x, int y)
    {
        if (y + _wordLenght > _maxY || x + _wordLenght > _maxX)
            return false;

        var word = string.Empty;

        for (int i = 0; i < _wordLenght; i++)
        {
            word += _input[y + i][x + i];
        }
        return Regex.IsMatch(word, _searchPattern);
    }

    private bool IsLeftDiagWordValid(int x, int y)
    {
        if (y + _wordLenght > _maxY || x - _wordLenght < -1)
            return false;

        var word = string.Empty;

        for (int i = 0; i < _wordLenght; i++)
        {
            word += _input[y + i][x - i];
        }
        return Regex.IsMatch(word, _searchPattern);
    }


}
