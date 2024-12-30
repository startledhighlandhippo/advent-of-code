List<int> totals = new();

int currentTotal = 0;
foreach (string line in System.IO.File.ReadLines("input.txt"))
{
    if (line != "")
    {
        currentTotal += int.Parse(line);
    }
    else
    {
        totals.Add(currentTotal);
        currentTotal = 0;
    }
}

List<int> orderedTotals = totals.OrderByDescending(t => t).Select(t => t).ToList<int>();

int topThreeTotal = orderedTotals.Take(3).Sum();

Console.WriteLine(topThreeTotal);