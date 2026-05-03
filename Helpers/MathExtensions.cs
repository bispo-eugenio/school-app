namespace schoolApi.Helpers;

public static class MathExtensions
{
    public static decimal Average(decimal[] decimals)
    {
        if (decimals == null || decimals.Length == 0)
            return 0;

        decimal total = 0;
        foreach (var index in decimals)
        {
            total += index;
        }

        return total / decimals.Length;
    }
}
