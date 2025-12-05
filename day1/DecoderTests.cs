using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace day1;

public class Decoder(int number)
{
    public Dial Dial { get { return dial; } }

    public int ZeroHits { get; internal set; }
    public int ZeroPasses { get; internal set; }

    private readonly Dial dial = new(number);

    internal Decoder Execute(string instruction)
    {
        var step = int.Parse(instruction[1..]);
        if(instruction.StartsWith('L'))
        {
            dial.RotateLeft(step);
        }
        else if (instruction.StartsWith('R'))
        {
            dial.RotateRight(step);
        }
        ZeroPasses += dial.ZeroPasses;
        if(dial.CurrentNumber == 0) ZeroHits++;
        return this;
    }

    internal Decoder Execute(string[] instructions)
    {
        foreach(var instruction in instructions)
        {
            Execute(instruction);
        }
        return this;
    }
}

public class DecoderTests
{
    // [Test]
    // public void DecoderReadsFileInput_Part1()
    // {
    //     var input = new List<string>();
    //     var sr = new StreamReader(@"C:\Code\adventofcode2025\day1\input.txt");
    //     string? line = sr.ReadLine();
    //     if(line != null) input.Add(line);
    //     while (line != null)
    //     {
    //         line = sr.ReadLine();
    //         if(line != null) input.Add(line);
    //     }
    //     sr.Close();

    //     var decoder = new Decoder(50).Execute([.. input]);
    //     decoder.ZeroHits.Should().Be(1129);
    //     decoder.ZeroPasses.Should().Be(5509);
    // }

    [TestCase(0, 10)]
    [TestCase(1, 10, "L20")]
    [TestCase(0, 10, "L10")]
    [TestCase(1, 10, "L20", "R10")]
    [TestCase(0, 10, "L10", "L10", "R10")]
    [TestCase(3, 50, "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    public void DecoderCountsZeroPasses(int expectedZeroPasses, int startIncrement, params string[] instructions)
    {
        new Decoder(startIncrement).Execute(instructions).ZeroPasses.Should().Be(expectedZeroPasses);
    }

    [TestCase(0, 10)]
    [TestCase(0, 10, "L20")]
    [TestCase(1, 10, "L10")]
    [TestCase(1, 10, "L20", "R10")]
    [TestCase(2, 10, "L10", "L10", "R10")]
    [TestCase(3, 50, "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82")]
    public void DecoderCountsZeroHits(int expectedZeroHits, int startIncrement, params string[] instructions)
    {
        new Decoder(startIncrement).Execute(instructions).ZeroHits.Should().Be(expectedZeroHits);
    }

    [Test]
    public void DecoderCanExecuteMultipleInstructions()
    {
        new Decoder(0).Execute(["R7", "L5"]).Dial.CurrentNumber.Should().Be(2);
    }

    [Test]
    public void DecoderTurnsDialRightOnAnRInstruction()
    {
        new Decoder(0).Execute("R7").Dial.CurrentNumber.Should().Be(7);
    }

    [Test]
    public void DecoderTurnsDialLeftOnAnLInstruction()
    {
        new Decoder(0).Execute("L5").Dial.CurrentNumber.Should().Be(95);
    }
}