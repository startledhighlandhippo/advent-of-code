using System.Data;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(partOne("input.txt"));
        Console.WriteLine(partTwo("input.txt"));
    }

    public static int partOne(string filePath)
    {
        int xmasCount = 0;
        char[] xmasChars = ['X','M','A','S'];
        string[] inputLines = File.ReadAllLines(filePath);
        List<(List<int>, List<int>)> checkOffsets = new()
        {
            ([0, 0, 0, 0], [0, 1, 2, 3]),        // Right
            ([0, 1, 2, 3], [0, 1, 2, 3]),        // Down-Right
            ([0, 1, 2, 3], [0, 0, 0, 0]),        // Down
            ([0, 1, 2, 3], [0, -1, -2, -3]),     // Down-Left
            ([0, 0, 0, 0], [0, -1, -2, -3]),     // Left
            ([0, -1, -2, -3], [0, -1, -2, -3]),  // Up-Left
            ([0, -1, -2, -3], [0, 0, 0, 0]),     // Up
            ([0, -1, -2, -3], [0, 1, 2, 3])      // Up-Right
        };

        for (int i = 0; i < inputLines.Count(); i++)
        {
            for (int j = 0; j < inputLines[i].Count(); j++)
            {
                char currentChar = inputLines[i][j];
                if (currentChar != xmasChars[0])
                {
                    continue;
                }

                for (int k = 0; k < checkOffsets.Count(); k++)
                {
                    if (check(i, j, checkOffsets[k], inputLines, xmasChars))
                    {
                        xmasCount += 1;
                    }
                }
            }
        }

        return xmasCount;
    }

    public static int partTwo(string filePath)
    {
        int xmasCount = 0;
        char[] xmasChars = ['M','A','S'];
        string[] inputLines = File.ReadAllLines(filePath);
        List<(List<int>, List<int>)> checkOffsets = new()
        {
            ([-1, 0, 1], [-1, 0, 1]),      // NW to SE
            ([1, 0, -1], [-1, 0, 1])       // SW to NE
        };

        for (int i = 0; i < inputLines.Count(); i++)
        {
            for (int j = 0; j < inputLines[i].Count(); j++)
            {
                char currentChar = inputLines[i][j];
                if (currentChar != 'A')
                {
                    continue;
                }

                bool nwToSeForward = check(i, j, checkOffsets[0], inputLines, ['M', 'A', 'S']);
                bool nwToSeReverse = check(i, j, checkOffsets[0], inputLines, ['S', 'A', 'M']);
                bool nwToSe = nwToSeForward || nwToSeReverse;

                bool swToNeForward = check(i, j, checkOffsets[1], inputLines, ['M', 'A', 'S']);
                bool swToNeReverse = check(i, j, checkOffsets[1], inputLines, ['S', 'A', 'M']);
                bool swToNe = swToNeForward || swToNeReverse;

                xmasCount += nwToSe && swToNe ? 1 : 0;
            }
        }

        return xmasCount;
    }

    public static bool check(int rowIndex, int colIndex, (List<int>, List<int>) checkOffsets, string[] inputLines, char[] desiredChars)
    {
        List<int> rowOffsets = checkOffsets.Item1;
        List<int> colOffsets = checkOffsets.Item2;

        int rowMax = inputLines.Count();
        int colMax = inputLines[0].Count();  // hope rows aren't variable in length!

        if(rowIndex + rowOffsets.Max() >= rowMax || rowIndex + rowOffsets.Min() < 0
            || colIndex + colOffsets.Max() >= colMax || colIndex + colOffsets.Min() < 0 )
        {
            return false;
        }

        List<char> asFound = new();
        for (int i = 0; i < checkOffsets.Item1.Count; i++)
        {
            asFound.Add(inputLines[rowIndex + rowOffsets[i]][colIndex + colOffsets[i]]);
        }

        return asFound.SequenceEqual(desiredChars);
    }
}