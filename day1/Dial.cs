namespace day1;

public class Dial(int number)
{
    private const int NumberOfIncrements = 100;

    public int CurrentNumber { get { return number; } }

    public int ZeroPasses { get; internal set; }

    internal Dial RotateRight(int step)
    {
        ZeroPasses = CalculateZeroPasses(step);

        number += step;
        number %= NumberOfIncrements;
        return this;
    }

    internal Dial RotateLeft(int step)
    {
        int zeroPasses;
        if (number == 0)
        {
            zeroPasses = CalculateZeroPasses(step);
        }
        else
        {
            // this does work:
            zeroPasses = ((((number - step) * -1) - 1) + NumberOfIncrements) / NumberOfIncrements;

            // this doesn't work but not clear on the difference between the methods or appropriate test cases to expose the issue:
            // if ((number - step) < 0)
            // {
            //     zeroPasses = 1 + (step - 2) / NumberOfIncrements;
            // }
        }

        var leftStepConvertedToRightStep = NumberOfIncrements - (step % NumberOfIncrements);
        RotateRight(leftStepConvertedToRightStep);

        ZeroPasses = zeroPasses;
        return this;
    }

    private int CalculateZeroPasses(int step)
    {
        if ((number + step) > NumberOfIncrements)
        {
            return (number + step - 1) / NumberOfIncrements;
        }
        return 0;
    }
}
