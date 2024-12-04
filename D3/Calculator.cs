namespace D3;

public class Calculator
{
    public static int ExecuteMulInstruction(string instruction)
    {
        string[] parts = instruction.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int a = int.Parse(parts[1]);
        int b = int.Parse(parts[2]);
        return a * b;
    }
}
