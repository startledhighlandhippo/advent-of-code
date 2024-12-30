using System.Text.RegularExpressions;

Console.WriteLine(partOne());
Console.WriteLine(partTwo());

int partOne()
{
    int total = 0;
    foreach (string line in File.ReadLines("input.txt"))
    {
        MatchCollection matches = Regex.Matches(line, "\\d");
        int value = int.Parse($"{matches.First()}{matches.Last()}");
        total += value;
    }
    return total;
}

int partTwo()
{
    int total = 0;
    List<(string, string)> digits = new()
    {
        ("zero", "0"),
        ("one", "1"),
        ("two", "2"),
        ("three", "3"),
        ("four", "4"),
        ("five", "5"),
        ("six", "6"),
        ("seven", "7"),
        ("eight", "8"),
        ("nine", "9"),
    };
    string pattern = string.Join('|', digits.Select(d => d.Item1));
    pattern = $"(?=(\\d|{pattern}))";
    foreach (string line in File.ReadLines("input.txt"))
    {
        MatchCollection matches = Regex.Matches(line, pattern);

        string first = matches.First().Groups[1].Value;
        string firstNum = digits.Select(d => d.Item1).Contains(first) ?
            digits.Where(d => d.Item1 == first).Single().Item2 :
            first;

        string last = matches.Last().Groups[1].Value;
        string lastNum = digits.Select(d => d.Item1).Contains(last) ?
            digits.Where(d => d.Item1 == last).Single().Item2 :
            last;

        total += int.Parse($"{firstNum}{lastNum}");
    }
    return total;
}