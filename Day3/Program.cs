string input = "input.txt";

string[] data = File.ReadAllLines(input);

int PartOne()
{
    List<int> itemsPriorities = new();

    foreach(string rucksack in data)
    {
        string firstCompartment = rucksack.Substring(0, rucksack.Length / 2);
        string secondCompartment = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);

        var commonItem = firstCompartment.Intersect(secondCompartment).First();

        int priority = char.IsLower(commonItem) ? (int)(commonItem - '0') - 48 : (int)(commonItem - '0') + 10;

        itemsPriorities.Add(priority);
    }

    return itemsPriorities.Sum();
}

Console.WriteLine($"Sum of priorities of common items: {PartOne()}");