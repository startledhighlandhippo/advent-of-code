using System.Text.RegularExpressions;

string[] lines = System.IO.File.ReadAllLines("input_test.txt");

Console.WriteLine(puzzle1(lines));

string puzzle1(string[] input)
{
    List<List<char?>> crateTable = new();
    bool tableStarted = false;
    bool tableTransposed = true;
    bool processMoves = false;
    List<List<char>> crateTable2 = new();

    foreach (string line in input)
    {
        if (!processMoves)
        {
            List<char?>? contents = ParseCrateLine(line);
            if (contents != null)
            {
                crateTable.Add(contents);
            }
            else if (line == "")
            {
                processMoves = true;
            }
        }
        else
        {
            // Transpose the table
            if (!tableTransposed)
            {
                crateTable.Reverse();
                foreach(List<char?> row in crateTable)
                {
                    for (int i = 0; i <= row.Count; i++)
                    {
                        char? crate = row[i];

                        if (!tableStarted)
                        {
                            crateTable2.Add(crate == null ? new List<char>() : new List<char>() { crate ?? '_' });
                        }
                        else if (crate != null)
                        {
                            crateTable2[i].Add(crate ?? '_');
                        }
                        
                    }
                    tableStarted = true;
                }
            }
            
            string pattern = @"move (?<numCrate>\d*) from (?<start>\d*) to (?<end>\d*)";
            Regex moveRegex = new Regex(pattern);

            GroupCollection details = moveRegex.Match(line).Groups;
            int numCrate = Int16.Parse(details.GetValueOrDefault("numCrate").Value);
            int start = Int16.Parse(details.GetValueOrDefault("start").Value);
            int end = Int16.Parse(details.GetValueOrDefault("end").Value);

        }
    }
    return "blah";
}

List<char?>? ParseCrateLine(string line)
{
    int charCounter = 0;
    bool inCrate = false;
    bool isCrateLine = false;
    char? crateChar = null;
    List<char?> contents = new();

    foreach (char character in line.ToCharArray())
    {
        if (charCounter < 3)
        {
            if (character == '[')
            {
                inCrate = true;
            }
            else if (character == ']')
            {
                inCrate = false;
            }
            else if ((int) character >= 65 && (int) character <= 90 && inCrate)
            {
                isCrateLine = true;
                crateChar = character;
            }
            charCounter++;
        }
        if (charCounter == 4)
        {
            contents.Add(crateChar);
            charCounter = 0;
        }
    }

    return isCrateLine ? contents : null;
}