
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

        // part 1
        Console.WriteLine($"total joltage = {input.Sum(batteryBank => long.Parse(JoltageCalculator.CalculateMaxJoltage(batteryBank)))}");
        // part 2 - too low
        Console.WriteLine($"total joltage = {input.Sum(batteryBank => long.Parse(JoltageCalculator.CalculateMaxJoltage2(batteryBank, 12)))}");
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

    [TestCase("818181911112111", "9211", 4)]
    [TestCase("987654321111111", "987", 3)]
    [TestCase("811111111111119", "819", 3)]
    [TestCase("234234234234278", "478", 3)]
    [TestCase("818181911112111", "921", 3)]
    [TestCase("987654321111111", "98", 2)]
    [TestCase("811111111111119", "89", 2)]
    [TestCase("234234234234278", "78", 2)]
    [TestCase("818181911112111", "92", 2)]
    [TestCase("123", "23", 2)]
    [TestCase("12", "12", 2)]
    [TestCase("121", "21", 2)]
    [TestCase("111", "11", 2)]
    [TestCase("21", "21", 2)]
    [TestCase("11", "11", 2)]
    public void MaximumJoltageOfABankIsCombinationOfNDigits(string bank, string expectedMaxJoltage, int n)
    {
        JoltageCalculator.CalculateMaxJoltage2(bank, n).Should().Be(expectedMaxJoltage);
    }
}
