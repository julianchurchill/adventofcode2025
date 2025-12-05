using FluentAssertions;
using NUnit.Framework;

namespace day1;

public class DialTests
{
    [TestCase(0, 1)]
    [TestCase(0, 100)]
    [TestCase(1, 101)]
    [TestCase(1, 200)]
    [TestCase(2, 201)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 2, 1)]
    [TestCase(1, 101, 1)]
    [TestCase(2, 102, 1)]
    [TestCase(1, 68, 50)]
    [TestCase(10, 1000, 50)]
    public void CountsZeroPassesOnLeftRotation(int expectedZeroPasses, int leftStep, int startIncrement = 0)
    {
        new Dial(startIncrement).RotateLeft(leftStep).ZeroPasses.Should().Be(expectedZeroPasses);
    }

    [TestCase(0, 1)]
    [TestCase(0, 100)]
    [TestCase(1, 101)]
    [TestCase(1, 200)]
    [TestCase(2, 201)]
    [TestCase(0, 1, 99)]
    [TestCase(1, 2, 99)]
    [TestCase(1, 101, 99)]
    [TestCase(2, 102, 99)]
    [TestCase(10, 1000, 50)]
    public void CountsZeroPassesOnRightRotation(int expectedZeroPasses, int rightStep, int startIncrement = 0)
    {
        new Dial(startIncrement).RotateRight(rightStep).ZeroPasses.Should().Be(expectedZeroPasses);
    }

    [Test]
    public void RightRotationRepeatedlyPast99ContinuesFrom0()
    {
        new Dial(0).RotateRight(101).CurrentNumber.Should().Be(1);
    }

    [Test]
    public void LeftRotationRepeatedlyPast0ContinuesFrom99()
    {
        new Dial(0).RotateLeft(101).CurrentNumber.Should().Be(99);
    }

    [Test]
    public void RightRotationPast99ContinuesFrom0()
    {
        new Dial(99).RotateRight(1).CurrentNumber.Should().Be(0);
    }

    [Test]
    public void LeftRotationPast0ContinuesFrom99()
    {
        new Dial(0).RotateLeft(1).CurrentNumber.Should().Be(99);
    }

    [Test]
    public void RightRotationIncreasesNumber()
    {
        new Dial(0).RotateRight(5).CurrentNumber.Should().Be(5);
    }

    [Test]
    public void LeftRotationIncreasesNumber()
    {
        new Dial(5).RotateLeft(5).CurrentNumber.Should().Be(0);
    }
}