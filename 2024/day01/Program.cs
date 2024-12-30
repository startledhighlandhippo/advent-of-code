using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine(partOne("input_part1.txt"));
Console.WriteLine(partTwo("input_part1.txt"));

int partOne(string inputFile)
{
    int totalDistance = 0;
    List<int> listOne = new();
    List<int> listTwo = new();

    foreach (string line in File.ReadLines(inputFile))
    {
        string[] digits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        listOne.Add(int.Parse(digits[0]));
        listTwo.Add(int.Parse(digits[1]));
    }

    listOne.Sort();
    listTwo.Sort();

    for (int i = 0; i < listOne.Count; i++)
    {
        totalDistance += Math.Abs(listOne[i] - listTwo[i]);
    }

    return totalDistance;
}

int partTwo(string inputFile)
{
    int similarity = 0;
    List<int> listOne = new();
    List<int> listTwo = new();

    foreach (string line in File.ReadLines(inputFile))
    {
        string[] digits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        listOne.Add(int.Parse(digits[0]));
        listTwo.Add(int.Parse(digits[1]));
    }

    for (int i = 0; i < listOne.Count; i++)
    {
        int value = listOne[i];

        int numOccurrences = listTwo.Where(v => v == value).Count();

        similarity += value * numOccurrences;
    }

    return similarity;
}