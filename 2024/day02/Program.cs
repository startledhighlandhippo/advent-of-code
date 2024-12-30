using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("-- PART ONE --");
Console.WriteLine(partOne("input_part1.txt"));
Console.WriteLine("");
Console.WriteLine("-- PART TWO --");
Console.WriteLine(partTwo("input_part1.txt"));

int partOne(string inputFile)
{
    int numSafe = 0;

    foreach (string line in File.ReadLines(inputFile))
    {
        int[] report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

        numSafe += isSafe(report) ? 1 : 0;
    }

    return numSafe;
}

int partTwo(string inputFile)
{
    int numSafe = 0;

    foreach (string line in File.ReadLines(inputFile))
    {
        int[] report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        bool safe = false;

        if(isSafe(report))
        {
            Console.WriteLine($"{line}: Safe without removing any level");
            safe = true;
        }
        else
        {
            for (int i = 0; i < report.Count(); i++)
            {
                int[] newReport = report.Where((v, j) => j != i).ToArray();
                if (isSafe(newReport))
                {
                    Console.WriteLine($"{line}: Safe by removing level {i + 1}, {report[i]}");
                    safe = true;
                    break;
                }
            }
        }

        if (safe)
        {
            numSafe += 1;
        }
        else
        {
            Console.WriteLine($"{line}: Unsafe regardless of which level is removed");
        }
    }

    return numSafe;
}

bool isSafe(int[] report) {
    bool increasing = false;
    bool decreasing = false;

    for (int i = 0; i < report.Count() - 1; i++) {
        int value1 = report[i];
        int value2 = report[i + 1];
        int difference = value1 - value2;

        if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
        {
            return false;
        }

        if (!increasing && !decreasing)
        {
            increasing = difference > 0;
            decreasing = difference < 0;
        }
        else if ((increasing && difference < 0) || (decreasing && difference > 0))
        {
            return false;
        }
    }

    return true;
}