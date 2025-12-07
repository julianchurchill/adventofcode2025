
using FluentAssertions;

namespace day3;

public class JoltageTests
{
    [Test]
    public void FindTotalJoltage()
    {
        var input = new List<string>();
        var sr = new StreamReader(@"C:\Code\adventofcode2025\day3\input.txt");
        string? line = sr.ReadLine();
        if(line != null) input.Add(line);
        while (line != null)
        {
            line = sr.ReadLine();
            if(line != null) input.Add(line);
        }
        sr.Close();

        Console.WriteLine($"total joltage = {input.Sum(batteryBank => int.Parse(JoltageCalculator.CalculateMaxJoltage(batteryBank)))}");
    }

    [TestCase("987654321111111", "98")]
    [TestCase("811111111111119", "89")]
    [TestCase("234234234234278", "78")]
    [TestCase("818181911112111", "92")]
    [TestCase("123", "23")]
    [TestCase("12", "12")]
    [TestCase("121", "21")]
    [TestCase("111", "11")]
    [TestCase("21", "21")]
    [TestCase("11", "11")]
    public void MaximumJoltageOfABankIsCombinationOfTwoDigits(string bank, string expectedMaxJoltage)
    {
        JoltageCalculator.CalculateMaxJoltage(bank).Should().Be(expectedMaxJoltage);
    }
}
