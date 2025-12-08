namespace day3;

public class JoltageCalculator
{
    public static string CalculateMaxJoltage2(string bank, int numberOfBatteriesToActivate)
    {
        var bankAsInts = bank.Select(c => int.Parse(c.ToString())).ToList();

        List<int> activatedBatteries = [];
        int searchStartIndex = 0;
        for(int activeBatteryCount = 0; activeBatteryCount < numberOfBatteriesToActivate; activeBatteryCount++)
        {
            // only look _after_ the highest digit for more max digits, slice end +1 to make it inclusive
            var searchEndIndex = bankAsInts.Count - numberOfBatteriesToActivate + activeBatteryCount + 1;
            var sliceToSearch = bankAsInts[searchStartIndex..searchEndIndex];
            var highestBattery = sliceToSearch.Max();
            var highestBatteryIndex = sliceToSearch.FindIndex(c => c == highestBattery) + searchStartIndex;
            activatedBatteries.Add(highestBattery);
            // set search start to after last highest battery
            searchStartIndex = highestBatteryIndex + 1;
        }

        return string.Join("", activatedBatteries);
    }

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
