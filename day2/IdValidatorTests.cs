
using FluentAssertions;

namespace day2;

public class IdValidatorTests
{
    [TestCase("1")]
    [TestCase("12")]
    [TestCase("121")]
    [TestCase("12121")]
    public void ValidSequencesAreNonRepeating(string id)
    {
        IdValidator.IsValid(id).Should().BeTrue();
    }

    [TestCase("55")]
    [TestCase("11")]
    [TestCase("111")]
    [TestCase("1212")]
    [TestCase("121212")]
    [TestCase("12121212")]
    [TestCase("1212121212")]
    [TestCase("12121212121212")]
    [TestCase("121212121212121212")]
    [TestCase("1212121212121212121212")]
    [TestCase("12341234")]
    public void InvalidIdsAreSequencesRepeatedAtLeastTwice(string id)
    {
        IdValidator.IsValid(id).Should().BeFalse();
    }
}
