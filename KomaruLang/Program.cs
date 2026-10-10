using KomaruLang.Functions;

namespace KomaruLang;

public class Program
{
    private static string[] ?script;

    public static void Main(string[] args)
    {
        script = File.ReadAllLines(args[0]);

        foreach (string line in script)
            ExecuteLine(line);
    }

    public static void ExecuteLine(string line)
    {
        var words = new List<string>();
        string readingWord = string.Empty;

        bool readingQuote = false;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
                readingQuote = !readingQuote;
            else
                if (line[i] != ' ')
                    readingWord += line[i];
                else if (readingQuote)
                    readingWord += line[i];

            if (line[i] == ' ' && !readingQuote || i == line.Length - 1)
            {
                words.Add(readingWord);
                readingWord = string.Empty;
            }
        }

        if (words.Count < 1)
            return;

        switch (words[0])
        {
            case "print":
                Print.Do(words[Print.STRING_ARGUMENT]);
                break;
            case "printl":
                PrintL.Do(words[PrintL.STRING_ARGUMENT]);
                break;
            case "var":
                VarType type;
                switch (words[Var.TYPE_ARGUMENT])
                {
                    case "int":
                        type = VarType.Integer;
                        break;
                    case "str":
                        type = VarType.String;
                        break;
                    default:
                        Console.WriteLine($"UNKNOWN TYPE: {words[Var.TYPE_ARGUMENT]}");
                        return;
                }

                Var.Do(type, words[Var.NAME_ARGUMENT], words[Var.VALUE_ARGUMENT]);
                break;
            case "varsee":
                VarSee.Do(words[VarSee.NAME_ARGUMENT]);
                break;
            case "varseel":
                VarSeeL.Do(words[VarSeeL.NAME_ARGUMENT]);
                break;
            default:
                Console.WriteLine($"UNKNOWN FUNCTION: {words[0]}");
                return;
        }
    }
}
