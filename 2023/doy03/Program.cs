using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml.Schema;

string[] lines = File.ReadAllLines("input.txt");
int numColumns = lines[0].Length;
int numRows = lines.Length;

Console.WriteLine(partOne());

int partOne()
{
    string stringNumber = "";
    bool inNumber = false;
    bool isPartNumber = false;

    int sum = 0;

    for (int r = 0; r < numRows; r++)
    {
        for (int c = 0; c < numColumns; c++)
        {
            string current = lines[r][c].ToString();
            if (Regex.IsMatch(current, "\\d"))
            {
                inNumber = true;
                stringNumber += current;
                isPartNumber = isPartNumber || checkForPartNumber(r, c);
            }
            else if (inNumber)
            {
                if (isPartNumber)
                {
                    Console.WriteLine($"{stringNumber} | {isPartNumber}");
                    sum += int.Parse(stringNumber);
                }
                inNumber = false;
                isPartNumber = false;
                stringNumber = "";
            }
        }
    }

    return sum;
}

bool checkForPartNumber(int row, int column)
{
    List<(int, int)> coordinates = new()
    {
        (row - 1, column - 1),
        (row - 1, column),
        (row - 1, column + 1),
        (row, column - 1),
        (row, column + 1),
        (row + 1, column - 1),
        (row + 1, column),
        (row + 1, column + 1)
    };

    foreach((int, int) coordinatePair in coordinates)
    {
        if (coordinatePair.Item1 < 0 || coordinatePair.Item2 < 0 ||
            coordinatePair.Item1 >= numRows || coordinatePair.Item2 >= numColumns)
        {
            continue;
        }
        else if (!Regex.IsMatch(lines[coordinatePair.Item1][coordinatePair.Item2].ToString(), "\\d|\\."))
        {
            return true;
        }
    }

    return false;
}