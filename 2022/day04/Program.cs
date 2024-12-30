string[] input = System.IO.File.ReadAllLines("input.txt");

Console.WriteLine(puzzle2(input));


int puzzle1(string[] input)
{
    int overlaps = 0;

    foreach (string line in input)
    {
        string[] assignments = line.Split(',');
        string elf1 = assignments[0];
        string elf2 = assignments[1];

        int elf1First = Int16.Parse(elf1.Split('-')[0]);
        int elf1Last = Int16.Parse(elf1.Split('-')[1]);
        int elf2First = Int16.Parse(elf2.Split('-')[0]);
        int elf2Last = Int16.Parse(elf2.Split('-')[1]);

        if (elf1First <= elf2First && elf1Last >= elf2Last || elf2First <= elf1First && elf2Last >= elf1Last)
        {
            overlaps++;
        }
    }

    return overlaps;
}

int puzzle2(string[] input)
{
    int overlaps = 0;

    foreach (string line in input)
    {
        string[] assignments = line.Split(',');
        string elf1 = assignments[0];
        string elf2 = assignments[1];

        int elf1First = Int16.Parse(elf1.Split('-')[0]);
        int elf1Last = Int16.Parse(elf1.Split('-')[1]);
        int elf2First = Int16.Parse(elf2.Split('-')[0]);
        int elf2Last = Int16.Parse(elf2.Split('-')[1]);

        if (elf1First <= elf2First && elf1Last >= elf2First ||
            elf1Last >= elf2Last && elf1First <= elf2Last ||
            elf2First <= elf1First && elf2Last >= elf1First || 
            elf2Last >= elf1Last && elf2First <= elf1Last)
        {
            overlaps++;
        }
    }

    return overlaps;
}