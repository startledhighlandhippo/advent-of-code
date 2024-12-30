string[] input = System.IO.File.ReadAllLines("input.txt");

Console.WriteLine(puzzle1(input));

int puzzle1(string[] input)
{
    int result = 0;
    int cycleCount = 0;
    int cycleIncrement = 0;
    int registerX = 1;
    int cyclesOfInterestStart = 20;
    int cyclesOfInterestIncrement = 40;
    int cyclesOfInterestMax = 220;
    int cyclesOfInterestCount = 0;

    foreach (string instruction in input)
    {
        int nextCycleOfInterest = cyclesOfInterestIncrement * cyclesOfInterestCount + cyclesOfInterestStart;

        cycleIncrement = instruction.StartsWith("noop") ? 1 : 2;
        cycleCount += cycleIncrement;

        if (cycleCount >= nextCycleOfInterest)
        {
            result += (nextCycleOfInterest * registerX);
            cyclesOfInterestCount += 1;
            if (nextCycleOfInterest >= cyclesOfInterestMax)
            {
                break;
            }
        }

        if (instruction.StartsWith("addx"))
        {
            int value = Int32.Parse(instruction.Replace("addx ", ""));
            registerX += value;
        }
    }

    return result;
}