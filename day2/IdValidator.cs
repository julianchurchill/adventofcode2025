namespace day2;

public class IdValidator
{
    public static bool IsValid(string id)
    {
        if (id.Length == 1) return true;

        if (AllCharsTheSame(id)) return false;

        // Detect repeats starting with N as highest prime <= id length
        if (DoesIdRepeatNTimes(id, 11)) return false;
        if (DoesIdRepeatNTimes(id, 7)) return false;
        if (DoesIdRepeatNTimes(id, 5)) return false;
        if (DoesIdRepeatNTimes(id, 3)) return false;
        if (DoesIdRepeatNTimes(id, 2)) return false;
        return true;
    }

    private static bool DoesIdRepeatNTimes(string id, int n)
    {
        if (id.Length % n != 0) return false;

        var stepSize = id.Length / n;
        for (int i = 0; i < id.Length / n; i++)
        {
            for (int j = i + stepSize; j < id.Length; j += stepSize)
            {
                if (id[i] != id[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool AllCharsTheSame(string id)
    {
        return id.All(c => c == id[0]);
    }
}
