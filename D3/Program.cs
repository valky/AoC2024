

using D3;

var memoryReader = new MemoryReader("real_inputs.txt");

var total1 = 0;
foreach (var match in memoryReader.ReadMulFromCorruptMemory())
{
   total1 += Calculator.ExecuteMulInstruction(match);
}

Console.WriteLine(total1);

var total = 0;
foreach (var match in memoryReader.ReadMulWithEnableFromCorruptMemory())
{
    total += Calculator.ExecuteMulInstruction(match);
}

Console.WriteLine(total);

