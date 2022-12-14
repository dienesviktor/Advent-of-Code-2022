string input = "input.txt";

string[] data = File.ReadAllLines(input);

int PartOne()
{
    List<int> pointsPerGames = new();

    foreach (string line in data)
    {
        int myPoints = 0;

        int opponentChoice = 0;
        int myChoice = 0;

        switch (line.Split(' ')[0])
        {
            case "A":
                opponentChoice = 1;
                break;
            case "B":
                opponentChoice = 2;
                break;
            case "C":
                opponentChoice = 3;
                break;
        }

        switch (line.Split(' ')[1])
        {
            case "X":
                myChoice = 1;
                break;
            case "Y":
                myChoice = 2;
                break;
            case "Z":
                myChoice = 3;
                break;
        }

        myPoints += myChoice;

        myPoints += myChoice == 3 && opponentChoice == 2 || myChoice == 1 && opponentChoice == 3 || myChoice == 2 && opponentChoice == 1 ? 6 :
        myChoice == opponentChoice ? 3 : 0;

        pointsPerGames.Add(myPoints);
    }

    return pointsPerGames.Sum();
}

int PartTwo()
{
    List<int> pointsPerGames = new();

    foreach (string line in data)
    {
        int myPoints = 0;

        int opponentChoice = 0;
        int myChoice = 0;

        switch (line.Split(' ')[0])
        {
            case "A":
                opponentChoice = 1;
                break;
            case "B":
                opponentChoice = 2;
                break;
            case "C":
                opponentChoice = 3;
                break;
        }

        switch (line.Split(' ')[1])
        {
            case "X":
                myChoice = opponentChoice == 1 ? 3 : opponentChoice == 2 ? 1 : 2;
                break;
            case "Y":
                myChoice = opponentChoice;
                break;
            case "Z":
                myChoice = opponentChoice == 1 ? 2 : opponentChoice == 2 ? 3 : 1;
                break;
        }

        myPoints += myChoice;

        myPoints += myChoice == 3 && opponentChoice == 2 || myChoice == 1 && opponentChoice == 3 || myChoice == 2 && opponentChoice == 1 ? 6 :
        myChoice == opponentChoice ? 3 : 0;

        pointsPerGames.Add(myPoints);
    }

    return pointsPerGames.Sum();
}

Console.WriteLine($"Total score by following the strategy guide: {PartOne()}");
Console.WriteLine($"Total score by following the elf instructions: {PartTwo()}");