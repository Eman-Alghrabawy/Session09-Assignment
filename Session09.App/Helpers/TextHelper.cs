namespace Session09.App.Helpers;

// Part 5 - Q9: Extension methods on string.
// An extension method is a static method inside a static class whose first parameter has the "this" keyword.
public static class TextHelper
{
    // Bonus step 1 (how it started): a NORMAL static method.
    //   public static bool IsShorterThan(string value, int length) => value.Length < length;
    //   Usage: TextHelper.IsShorterThan("Stethoscope", 5);
    //
    // Bonus step 2: add "this" to the first parameter -> it becomes an EXTENSION method.
    //   Usage: "Stethoscope".IsShorterThan(5);
    public static bool IsShorterThan(this string value, int length)
    {
        return value.Length < length;
    }

    // Repeats the string "times" times. Example: "Ha".Repeat(3) -> "HaHaHa"
    public static string Repeat(this string value, int times)
    {
        return string.Concat(Enumerable.Repeat(value, times));
    }
}
