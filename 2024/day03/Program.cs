using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

Console.WriteLine("-- PART ONE --");
Console.WriteLine(partOne("input.txt"));
Console.WriteLine("");
Console.WriteLine("-- PART TWO --");
Console.WriteLine(partTwo("input.txt"));

int partOne(string inputFile)
{
    int result = 0;
    string pattern = @"mul\((\d+),(\d+)\)";
    Regex regex = new Regex(pattern);
    string contents = File.ReadAllText(inputFile);
    MatchCollection matches = regex.Matches(contents);
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;
        int first = int.Parse(groups[1].Value);
        int second = int.Parse(groups[2].Value);
        result += first * second;
    }

    return result;
}

int partTwo(string inputFile)
{
    int result = 0;
    string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
    Regex regex = new Regex(pattern);
    string contents = File.ReadAllText(inputFile);
    MatchCollection matches = regex.Matches(contents);
    bool enabled = true;
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;

        if (groups[0].Value == "do()")
        {
            enabled = true;
            continue;
        }

        if (groups[0].Value == "don't()")
        {
            enabled = false;
            continue;
        }

        if (enabled)
        {
            int first = int.Parse(groups[1].Value);
            int second = int.Parse(groups[2].Value);
            result += first * second;
        }
    }

    return result;
}