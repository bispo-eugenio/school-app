namespace schoolApi.Helpers;

public static class DualIdParse
{
    public static List<int>? TryParseId(string dualId)
    {
        List<int> result = [];
        var array = dualId.Split("-").ToList();
        if (array.Count != 2 &&
        array.GetType() == typeof(List<int>))
            return null;

        foreach (var index in array)
        {
            if (!int.TryParse(index, out int value))
                return null;
            result.Add(value);
        }

        return result;
    }
}
