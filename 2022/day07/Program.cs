using DaySeven;

string[] input = System.IO.File.ReadAllLines("input_test.txt");
MyDirectory? tree = null;
MyDirectory? currentDirectory = null;

foreach (string line in input)
{
    if (line.StartsWith("$ cd "))
    {
        string directory = line.Split("$ cd ")[^1];
        if (directory == "/")
        {
            if (tree == null)
            {
                tree = new MyDirectory("/");
            }
            currentDirectory = tree;
        }
    }
}