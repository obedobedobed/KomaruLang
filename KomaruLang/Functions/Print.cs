namespace KomaruLang.Functions;

public static class Print
{
    public const int STRING_ARGUMENT = 1;

    public static void Do(string str)
    {
        Console.Write(str);
    }
}
