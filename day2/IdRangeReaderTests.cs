
using FluentAssertions;

namespace day2;

internal class IdRangeReader
{
    internal static List<string> GetAllIds(string allRanges)
    {
        return [.. allRanges.Split(',')
            .Select(range =>
            {
                var bounds = range.Split('-');
                return new { Start = long.Parse(bounds.First()), End = long.Parse(bounds.Last()) };
            })
            .SelectMany(bounds =>
            {
                var ids = new List<string>();
                for(long i = bounds.Start; i <= bounds.End; i++)
                {
                    ids.Add(i.ToString());
                }
                return ids;
            })];
    }
}

public class IdRangeTests
{
    // [Test]
    // public void AddUpInvalidIdsFromInputFile()
    // {
    //     var input = new List<string>();
    //     var sr = new StreamReader(@"C:\Code\adventofcode2025\day2\input.txt");
    //     string? line = sr.ReadLine();
    //     if(line != null) input.Add(line);
    //     while (line != null)
    //     {
    //         line = sr.ReadLine();
    //         if(line != null) input.Add(line);
    //     }
    //     sr.Close();

    //     var ids = IdRangeReader.GetAllIds(input.First());
    //     var invalidIds = ids.Where(id => IdValidator.IsValid(id) == false).ToList();
    //     // Console.WriteLine(string.Join(",", invalidIds));
    //     // part 2 answer
    //     invalidIds.Select(long.Parse).Sum().Should().Be(26202168557L);
    //     // part 1 answer
    //     // invalidIds.Select(long.Parse).Sum().Should().Be(18893502033L);
    // }

    [TestCase("11-22", "11", "22")]
    public void ReadAStringAndFindAllInvalidIds(string input, params string[] invalidIds)
    {
        var ids = IdRangeReader.GetAllIds(input);
        ids.Where(id => IdValidator.IsValid(id) == false).Should().BeEquivalentTo(invalidIds);
    }

    [Test]
    public void IdRangeReaderSplitsRangesThatAreGreaterThanOne()
    {
        IdRangeReader.GetAllIds("1-3").Should().BeEquivalentTo(["1", "2", "3"]);
    }

    [Test]
    public void IdRangeReaderSplitsOutMultipleRangesOfIds()
    {
        IdRangeReader.GetAllIds("1-2,5-6").Should().BeEquivalentTo(["1", "2", "5", "6"]);
    }

    [Test]
    public void IdRangeReaderSplitsOutIds()
    {
        IdRangeReader.GetAllIds("1-2").Should().BeEquivalentTo(["1", "2"]);
    }
}