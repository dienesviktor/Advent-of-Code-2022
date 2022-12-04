string input = "input.txt";

string[] data = File.ReadAllLines(input);

int PartOne()
{
    int counter = 0;

    foreach(string line in data)
    {
        (int, int) firstElfRange = (int.Parse(line.Split(",")[0].Split("-")[0]), int.Parse(line.Split(",")[0].Split("-")[1]));
        (int, int) secondElfRange = (int.Parse(line.Split(",")[1].Split("-")[0]), int.Parse(line.Split(",")[1].Split("-")[1]));

        if (firstElfRange.Item1 >= secondElfRange.Item1 && firstElfRange.Item1 <= secondElfRange.Item2 && firstElfRange.Item2 >= secondElfRange.Item1 && firstElfRange.Item2 <= secondElfRange.Item2 || secondElfRange.Item1 >= firstElfRange.Item1 && secondElfRange.Item1 <= firstElfRange.Item2 && secondElfRange.Item2 >= firstElfRange.Item1 && secondElfRange.Item2 <= firstElfRange.Item2)
        {
            counter++;
        }
    }

    return counter;
}

Console.WriteLine($"Number of assignment pairs that one range fully contains the other: {PartOne()}");