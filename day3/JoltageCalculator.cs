namespace day3;

public class JoltageCalculator
{
    public static string CalculateMaxJoltage(string bank)
    {
        var bankAsInts = bank.Select(c => int.Parse(c.ToString())).ToList();
        var highestDigit = bankAsInts.Max();
        var highestDigitIndex = bankAsInts.FindIndex(c => c == highestDigit);

        int searchStartIndex = 0;
        List<int> secondDigitSearchRange = bankAsInts[..highestDigitIndex];
        if (highestDigitIndex + 1 < bankAsInts.Count)
        {
            searchStartIndex = highestDigitIndex + 1;
            secondDigitSearchRange = bankAsInts[searchStartIndex..];
        }
        var secondHighestDigit = secondDigitSearchRange.Max();
        var secondHighestDigitIndex = searchStartIndex + secondDigitSearchRange.FindIndex(c => c == secondHighestDigit);

        if (highestDigitIndex < secondHighestDigitIndex)
        {
            return $"{highestDigit}{secondHighestDigit}";
        }
        return $"{secondHighestDigit}{highestDigit}";
    }
}
