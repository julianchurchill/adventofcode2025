namespace day3;

public class JoltageCalculator
{
    public static string CalculateMaxJoltage2(string bank, int numberOfBatteriesToActivate)
    {
        var bankAsInts = bank.Select(c => int.Parse(c.ToString())).ToList();

        List<int> activatedBatteryIndexes = [];
        List<int> bankAsIntsCopy = bankAsInts[..];
        int searchStartIndex = 0;
        for(int activeBatteryCount = 0; activeBatteryCount < numberOfBatteriesToActivate; activeBatteryCount++)
        {
            // only look _after_ the highest digit for more max digits
            var sliceToSearch = bankAsIntsCopy[searchStartIndex..];
            var highestBattery = sliceToSearch.Max();
            var highestBatteryIndex = sliceToSearch.FindIndex(c => c == highestBattery) + searchStartIndex;
            activatedBatteryIndexes.Add(highestBatteryIndex);
            // ignore already found activated indexes
            bankAsIntsCopy[highestBatteryIndex] = 0;
            // reset search start when we have no > 0 values in the coming slice
            if (highestBatteryIndex + 1 == bankAsIntsCopy.Count ||
                bankAsIntsCopy[(highestBatteryIndex + 1)..].All(b => b == 0))
            {
                searchStartIndex = 0;
            }
            else
            {
                searchStartIndex = highestBatteryIndex + 1;
            }
        }

        activatedBatteryIndexes.Sort();
        return string.Join("", activatedBatteryIndexes.Select(index => bankAsInts[index]));
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
