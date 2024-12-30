using System.Drawing;

string[] input = System.IO.File.ReadAllLines("input.txt");

Console.WriteLine(puzzle1(input));

int puzzle1(string[] moves)
{
    Point head = new();
    Point tail = new();
    List<Point> tailPositions = new() { tail };

    foreach (string move in moves)
    {
        string direction = move.Split(' ')[0];
        int distance = Int16.Parse(move.Split(' ')[1]);

        for (int i = 0; i < distance; i++)
        {
            int step = direction == "L" || direction == "D" ? -1 : 1;

            if (direction == "R" || direction == "L")
            {
                head.X += step;
            }
            else
            {
                head.Y += step;
            }

            int distanceHoriz = head.X - tail.X;
            int distanceVert = head.Y - tail.Y;

            if (Math.Abs(distanceHoriz) > 1)
            {
                tail.X += Math.Sign(distanceHoriz);
                if (Math.Abs(distanceVert) == 1)
                {
                    tail.Y += Math.Sign(distanceVert);
                }
            }
            if (Math.Abs(distanceVert) > 1)
            {
                tail.Y += Math.Sign(distanceVert);
                if (Math.Abs(distanceHoriz) == 1)
                {
                    tail.X += Math.Sign(distanceHoriz);
                }
            }
            tailPositions.Add(tail);
        }
    }
    return tailPositions.Distinct().ToList().Count;
}