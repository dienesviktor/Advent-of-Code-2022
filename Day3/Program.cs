string input = "input.txt";

string[] data = File.ReadAllLines(input);

int PartOne()
{
    List<int> itemsPriorities = new();

    foreach(string rucksack in data)
    {
        string firstCompartment = rucksack.Substring(0, rucksack.Length / 2);
        string secondCompartment = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);

        char commonItem = firstCompartment.Intersect(secondCompartment).First();

        int priority = char.IsLower(commonItem) ? (int)(commonItem - '0') - 48 : (int)(commonItem - '0') + 10;

        itemsPriorities.Add(priority);
    }

    return itemsPriorities.Sum();
}

int PartTwo()
{
    List<int> groupPriorities = new();

    List<List<string>> groups = new();

    for(int rucksack = 0; rucksack < data.Length; rucksack+=3)
    {
        string first = data[rucksack];
        string second = data[rucksack + 1];
        string third = data[rucksack + 2];

        groups.AddRange(new List<List<string>> { new List<string> { first, second, third } });
    }

    foreach (var group in groups)
    {
        char commonItem = '\0';

        foreach (char item in group.First())
        {
            if (group[1].Contains(item) && group[2].Contains(item))
            {
                commonItem = item;
            }
        }

        int priority = char.IsLower(commonItem) ? (int)(commonItem - '0') - 48 : (int)(commonItem - '0') + 10;

        groupPriorities.Add(priority);
    }

    return groupPriorities.Sum();
}

Console.WriteLine($"Sum of priorities of common items: {PartOne()}");
Console.WriteLine($"Sum of priorities of groups' common items: {PartTwo()}");