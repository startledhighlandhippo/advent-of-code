int prioritySum = 0;

string[] lines = System.IO.File.ReadAllLines("input.txt");

for (int i = 0; i < lines.Length; i += 3)
{
    char[] elf1 = lines[i].ToCharArray();
    char[] elf2 = lines[i + 1].ToCharArray();
    char[] elf3 = lines[i + 2].ToCharArray();

    char[] badge = elf1.Intersect(elf2.Intersect(elf3)).ToArray<char>();

    foreach (char badgeChar in badge)
    {
        int asciiValue = (int) badgeChar;

        if (asciiValue >= 65 && asciiValue <= 90)
        {
            prioritySum += asciiValue - 64 + 26;
        }

        if (asciiValue >= 97 && asciiValue <= 122)
        {
            prioritySum += asciiValue - 96;
        }
    }

}

Console.WriteLine(prioritySum);
