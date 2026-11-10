namespace Task1.ShopSimulation.ConsoleUi;

internal sealed class ConsoleTerminal
{
    private const string InvalidNumberPrefix = "Please enter a whole number from ";
    private const string ToLabel = " to ";
    private const string Dot = ".";

    private readonly TextReader _input;
    private readonly TextWriter _output;

    public ConsoleTerminal(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    public void WriteLine(string text)
    {
        _output.WriteLine(text);
    }

    public string? ReadText(string prompt)
    {
        _output.Write(prompt);

        return _input.ReadLine();
    }

    public int? ReadNumber(string prompt, int minimum, int maximum)
    {
        string? line = ReadText(prompt);

        while (line != null && !IsNumberInRange(line, minimum, maximum))
        {
            WriteLine(InvalidNumberPrefix + minimum + ToLabel + maximum + Dot);
            line = ReadText(prompt);
        }

        return line == null ? null : int.Parse(line.Trim());
    }

    private static bool IsNumberInRange(string line, int minimum, int maximum)
    {
        return int.TryParse(line.Trim(), out int number) && number >= minimum && number <= maximum;
    }
}
