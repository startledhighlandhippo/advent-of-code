
using System.ComponentModel;
using System.Text.RegularExpressions;

string[] colors = { "red", "green", "blue" };

Console.WriteLine(partOne());
Console.WriteLine(partTwo());

int partOne()
{
    Dictionary<string, int> threshold = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };
    Dictionary<int, Dictionary<string, int>> results = new();

    string[] games = File.ReadAllLines("input.txt");
    foreach(string game in games)
    {
        Match gameNumMatch = Regex.Match(game, "Game (\\d+): ");
        int gameNum = int.Parse(gameNumMatch.Groups[1].Value);
        results.Add(gameNum, []);

        string[] rounds = game.Replace(gameNumMatch.Value, string.Empty).Split("; ");
        foreach(string round in rounds)
        {
            foreach(string color in colors)
            {
                string pattern = $"(\\d+) {color}";
                Match colorMatch = Regex.Match(round, pattern);
                int numCubes = colorMatch.Success ? int.Parse(colorMatch.Groups[1].Value) : 0;

                if (results[gameNum].TryGetValue(color, out int currentValue))
                {
                    results[gameNum][color] = Math.Max(currentValue, numCubes);
                }
                else
                {
                    results[gameNum].Add(color, numCubes);
                }
            }
        }
    }

    int[] qualifyingGames = results
    .Where(r => (r.Value["red"] <= threshold["red"]) &&
        (r.Value["green"] <= threshold["green"]) &&
        (r.Value["blue"] <= threshold["blue"]))
    .Select(r => r.Key)
    .ToArray();
        
    return qualifyingGames.Sum();
}

int partTwo()
{
    Dictionary<int, Dictionary<string, int>> results = new();

    string[] games = File.ReadAllLines("input.txt");
    int sumOfPowers = 0;
    foreach(string game in games)
    {
        Match gameNumMatch = Regex.Match(game, "Game (\\d+): ");
        int gameNum = int.Parse(gameNumMatch.Groups[1].Value);
        results.Add(gameNum, []);

        string[] rounds = game.Replace(gameNumMatch.Value, string.Empty).Split("; ");
        foreach(string round in rounds)
        {
            foreach(string color in colors)
            {
                string pattern = $"(\\d+) {color}";
                Match colorMatch = Regex.Match(round, pattern);
                int numCubes = colorMatch.Success ? int.Parse(colorMatch.Groups[1].Value) : 0;

                if (results[gameNum].TryGetValue(color, out int currentValue))
                {
                    results[gameNum][color] = Math.Max(currentValue, numCubes);
                }
                else
                {
                    results[gameNum].Add(color, numCubes);
                }
            }
        }

        int power = results[gameNum]["red"] * results[gameNum]["green"] * results[gameNum]["blue"];
        sumOfPowers += power;
    }
        
    return sumOfPowers;
}