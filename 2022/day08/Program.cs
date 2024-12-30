string[] input = System.IO.File.ReadAllLines("input.txt");

Console.WriteLine(puzzle2(input));

int puzzle1(string[] input)
{
    int numVisible = 0;
    List<List<int>> grid = new();
    List<int> row = new();

    foreach (string line in input)
    {
        row = new();

        foreach (char height in line.ToCharArray())
        {
            row.Add(int.Parse(height.ToString()));
        }

        grid.Add(row);
    }

    for (int i = 0; i < grid.Count; i++)
    {
        row = grid[i];
        for (int j = 0; j < row.Count; j++)
        {
            int height = row[j];
            List<int> column = new();
            for (int k = 0; k < grid.Count; k++)
            {
                column.Add(grid[k][j]);
            }

            if (i == 0 ||
                i == grid.Count - 1 ||
                j == 0 ||
                j == row.Count - 1 ||
                row.GetRange(0, j).Max() < height ||
                row.GetRange(j + 1, row.Count - (j + 1)).Max() < height ||
                column.GetRange(0, i).Max() < height ||
                column.GetRange(i + 1, grid.Count - (i + 1)).Max() < height)
            {
                numVisible++;
            }
        }
    }
    return numVisible;
}

int puzzle2(string[] input)
{
    int maxScore = 0;
    List<List<int>> grid = new();
    List<int> row = new();

    foreach (string line in input)
    {
        row = new();

        foreach (char height in line.ToCharArray())
        {
            row.Add(int.Parse(height.ToString()));
        }

        grid.Add(row);
    }

    for (int i = 0; i < grid.Count; i++)
    {
        row = grid[i];
        for (int j = 0; j < row.Count; j++)
        {
            int height = row[j];
            int? scenicScore = null;
            List<int> column = new();
            for (int k = 0; k < grid.Count; k++)
            {
                column.Add(grid[k][j]);
            }

            // Get lists of trees
            List<int> treesUp = column.GetRange(0, i);
            treesUp.Reverse();
            List<int> treesDown = column.GetRange(i + 1, grid.Count - (i + 1));
            List<int> treesLeft = row.GetRange(0, j);
            treesLeft.Reverse();
            List<int> treesRight = row.GetRange(j + 1, row.Count - (j + 1));

            List<List<int>> directions = new() { treesUp, treesDown, treesLeft, treesRight };
            foreach (List<int> direction in directions)
            {
                int distance = 0;
                foreach (int tree in direction)
                {
                    distance++;
                    if (tree >= height)
                    {
                        break;
                    }
                }
                scenicScore = scenicScore == null ? distance : scenicScore * distance;
            }
            maxScore = scenicScore > maxScore ? scenicScore ?? 0 : maxScore;
        }
    }
    return maxScore;
}