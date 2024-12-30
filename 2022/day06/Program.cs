string input = System.IO.File.ReadAllText("input.txt");

Console.WriteLine(puzzle2(input));

int puzzle(string input, int numChars)
{
    char[] inputChars = input.ToCharArray();
    int count = 0;

    List<char> currentChars = new();
    foreach(char character in inputChars)
    {
        currentChars.Add(character);
        count++;
        if (currentChars.Count > numChars)
        {
            currentChars.RemoveAt(0);
        }
        if (currentChars.Count == numChars)
        {
            List<char> testChars = currentChars.Distinct().ToList();
            if (testChars.Count == currentChars.Count)
            {
                break;
            }
        }
    }
    return count;
}

int puzzle1(string input)
{
    return puzzle(input, 4);
}

int puzzle2(string input)
{
    return puzzle(input, 14);
}