namespace KomaruLang.Functions;

public static class Var
{
    public const int TYPE_ARGUMENT = 1;
    public const int NAME_ARGUMENT = 2;
    public const int VALUE_ARGUMENT = 3;

    private static Dictionary<string, int> integers = new Dictionary<string, int>();
    private static Dictionary<string, string> strings = new Dictionary<string, string>();

    public static Dictionary<string, int> Integers { get { return integers; } }
    public static Dictionary<string, string> Strings { get { return strings; } }

    public static void Do(VarType type, string name, string value)
    {
        switch (type)
        {
            case VarType.Integer:
                int.TryParse(value, out int intValue);
                integers.Add(name, intValue);
                break;
            case VarType.String:
                strings.Add(name, value);
                break;
        }
    }
}

public enum VarType
{
    Integer,
    String
}