namespace day05;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(partOne("input.txt"));
        Console.WriteLine(partTwo("input.txt"));
    }

    static int partOne(string dataFile)
    {
        List<string> rawInput = File.ReadAllLines(dataFile).ToList();
        int divisionPoint = rawInput.FindIndex(x => x == string.Empty);
        List<string> rawRules = rawInput.Take(divisionPoint).ToList();
        List<string> rawPageLists = rawInput.Skip(divisionPoint + 1).ToList();

        List<(int, int)> rules = parseRules(rawRules);
        List<List<int>> pageLists = parsePageLists(rawPageLists);

        int result = 0;

        foreach (List<int> pageList in pageLists)
        {
            List<(int, int)> relevantRules = rules
                .Where(r => pageList.Contains(r.Item1) && pageList.Contains(r.Item2))
                .ToList();

            List<int> expectedOrder = new();
            int requiredRuleCount = pageList.Count() - 1;
            int currentPageIndex = 0;

            while (requiredRuleCount >= 0)
            {
                // Console.WriteLine($"{requiredRuleCount} | {currentPageIndex} | {pageList[currentPageIndex]} | {relevantRules.Where(r => r.Item1 == pageList[currentPageIndex]).Count()} | {string.Join(", ", relevantRules.Where(r => r.Item1 == pageList[currentPageIndex]))}");

                if (relevantRules.Where(x => x.Item1 == pageList[currentPageIndex]).Count() == requiredRuleCount)
                {
                    expectedOrder.Add(pageList[currentPageIndex]);
                    requiredRuleCount -= 1;
                }

                currentPageIndex = currentPageIndex == (pageList.Count() - 1) ? 0 : currentPageIndex + 1;
            }

            bool isCorrect = pageList.SequenceEqual(expectedOrder);
            // Console.WriteLine($"{isCorrect} | {string.Join(", ", pageList)} | {string.Join(", ", expectedOrder)}");

            if (isCorrect)
            {
                bool oddListCount = pageList.Count() % 2 != 0;
                int middleIndex = pageList.Count() % 2 != 0 ? pageList.Count() / 2 : pageList.Count() / 2 - 1;

                // Console.WriteLine($"{pageList.Count} | {middleIndex} | {pageList[middleIndex]} | {string.Join(", ", pageList)}");
                result += pageList[middleIndex];
            }
        }

        return result;
    }

    static int partTwo(string dataFile)
    {
        List<string> rawInput = File.ReadAllLines(dataFile).ToList();
        int divisionPoint = rawInput.FindIndex(x => x == string.Empty);
        List<string> rawRules = rawInput.Take(divisionPoint).ToList();
        List<string> rawPageLists = rawInput.Skip(divisionPoint + 1).ToList();

        List<(int, int)> rules = parseRules(rawRules);
        List<List<int>> pageLists = parsePageLists(rawPageLists);

        int result = 0;

        foreach (List<int> pageList in pageLists)
        {
            List<(int, int)> relevantRules = rules
                .Where(r => pageList.Contains(r.Item1) && pageList.Contains(r.Item2))
                .ToList();

            List<int> expectedOrder = new();
            int requiredRuleCount = pageList.Count() - 1;
            int currentPageIndex = 0;

            while (requiredRuleCount >= 0)
            {
                // Console.WriteLine($"{requiredRuleCount} | {currentPageIndex} | {pageList[currentPageIndex]} | {relevantRules.Where(r => r.Item1 == pageList[currentPageIndex]).Count()} | {string.Join(", ", relevantRules.Where(r => r.Item1 == pageList[currentPageIndex]))}");

                if (relevantRules.Where(x => x.Item1 == pageList[currentPageIndex]).Count() == requiredRuleCount)
                {
                    expectedOrder.Add(pageList[currentPageIndex]);
                    requiredRuleCount -= 1;
                }

                currentPageIndex = currentPageIndex == (pageList.Count() - 1) ? 0 : currentPageIndex + 1;
            }

            bool isCorrect = pageList.SequenceEqual(expectedOrder);
            // Console.WriteLine($"{isCorrect} | {string.Join(", ", pageList)} | {string.Join(", ", expectedOrder)}");

            if (!isCorrect)
            {
                bool oddListCount = expectedOrder.Count() % 2 != 0;
                int middleIndex = expectedOrder.Count() % 2 != 0 ? expectedOrder.Count() / 2 : expectedOrder.Count() / 2 - 1;

                // Console.WriteLine($"{expectedOrder.Count} | {middleIndex} | {expectedOrder[middleIndex]} | {string.Join(", ", expectedOrder)}");
                result += expectedOrder[middleIndex];
            }
        }

        return result;
    }

    static List<(int, int)> parseRules(List<string> rawRules)
    {
        List<(int, int)> rules = new();
        foreach (string rawRule in rawRules)
        {
            string[] ruleElements = rawRule.Split('|');
            bool elementOneResult = int.TryParse(ruleElements[0], out int elementOne);
            bool elementTwoResult = int.TryParse(ruleElements[1], out int elementTwo);

            if(!elementOneResult || !elementTwoResult)
            {
                Console.WriteLine($"Unable to parse rule: {rawRule}");
                continue;
            }

            rules.Add((elementOne, elementTwo));
        }

        return rules;
    }

    static List<List<int>> parsePageLists(List<string> rawPageLists)
    {
        List<List<int>> pageLists = new();
        foreach (string rawPageList in rawPageLists)
        {
            pageLists.Add(rawPageList.Split(',').Select(x => int.Parse(x)).ToList());
        }

        return pageLists;
    }
}
