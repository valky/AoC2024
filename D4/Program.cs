// See https://aka.ms/new-console-template for more information

using D4;


string[] lines = File.ReadAllLines("real_inputs.txt");

var wordCounter = new WordCounter(lines, "XMAS");

Console.WriteLine(wordCounter.CountWords());


var xWordCounter = new XWordCounter(lines, "MAS");

Console.WriteLine(xWordCounter.CountWords());
