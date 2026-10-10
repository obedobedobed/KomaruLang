namespace KomaruLang.Functions;

public static class PrintL
{
    public const int STRING_ARGUMENT = 1;

    public static void Do(string str)
    {
        Console.WriteLine(str);
    }
}
