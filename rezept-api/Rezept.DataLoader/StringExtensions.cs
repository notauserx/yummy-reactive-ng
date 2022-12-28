namespace Rezept.DataLoader;

public static class StringExtensions
{

    public static string BetweenBrackets(this string str) => Between(str, "(", ")");

    public static string Between(this string STR, string FirstString, string LastString)
    {
        string FinalString;
        int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
        int Pos2 = STR.IndexOf(LastString);

        if (Pos1 < 0 || Pos2 < 0) return String.Empty;
        FinalString = STR.Substring(Pos1, Pos2 - Pos1);
        return FinalString;
    }
}
