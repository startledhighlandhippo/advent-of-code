int myScore = new();

foreach (string line in System.IO.File.ReadLines("input_test.txt"))
{
    List<string> columns = line.Split(" ").ToList<string>();
    string theirMove = columns[0];
    string result = columns[1];

    theirMove = theirMove switch {
        "A" => "rock",
        "B" => "paper",
        "C" => "scissors",
        _ => throw new Exception()
    };

    result = result switch {
        "X" => "lose",
        "Y" => "draw",
        "Z" => "win",
        _ => throw new Exception()
    };

    string myMove = (theirMove, result) switch {
        ("rock", "win") => "paper",
        ("rock", "draw") => "rock",
        ("rock", "lose") => "scissors",
        ("paper", "win") => "scissors",
        ("paper", "draw") => "paper",
        ("paper", "lose") => "rock",
        ("scissors", "win") => "rock",
        ("scissors", "draw") => "scissors",
        ("scissors", "lose") => "paper",
        _ => throw new Exception()
    };

    int playValue = myMove switch {
        "rock" => 1,
        "paper" => 2,
        "scissors" => 3,
        _ => throw new Exception()
    };

    if (myMove == "rock" && theirMove == "scissors" ||
        myMove == "paper" && theirMove == "rock" ||
        myMove == "scissors" && theirMove == "paper")
    {
        myScore += 6 + playValue;
    }
    else if (myMove == theirMove)
    {
        myScore += 3 + playValue;
    }
    else
    {
        myScore += playValue;
    }
}

Console.WriteLine(myScore);