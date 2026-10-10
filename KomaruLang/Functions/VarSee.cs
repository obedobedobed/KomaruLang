namespace KomaruLang.Functions;

public static class VarSee
{
    public const int NAME_ARGUMENT = 1;

    public static void Do(string name)
    {
        string ?value;

        bool foundInIntegers = Var.Integers.TryGetValue(name, out int valueInt);
        if (foundInIntegers)
            value = valueInt.ToString();
        else
        {
            bool foundInStrings = Var.Strings.TryGetValue(name, out value);
            if (!foundInStrings)
                Console.WriteLine($"CANNOT GET VALUE: {name}");
        }

        Console.Write(value);
    }
}
