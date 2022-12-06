using System.Text;

string input = "input.txt";

string[] data = File.ReadAllLines(input);

const int cratesLength = 4;

int GetNumberOfStacks()
{
    return (int)Math.Ceiling(data[0].Length / (double)cratesLength);
}

List<List<char>> ParsingDataOfStacks()
{
    List<List<char>> stacks = new();

    foreach (int i in Enumerable.Range(0, GetNumberOfStacks()))
    {
        stacks.Add(new List<char>());
    }

    for (int @line = GetNumberOfStacks(); @line >= 0; @line--)
    {
        char[] characters = data[@line].ToCharArray();

        for (int @char = 0; @char < characters.Length; @char++)
        {
            if (char.IsLetter(characters[@char]))
            {
                char crate = characters[@char];
                int stack = @char / cratesLength;

                stacks[stack].Add(crate);
            }
        }
    }

    return stacks;
}

List<List<int>> ParsingRearrangementInput()
{
    List<List<int>> instructions = new();

    for (int @line = GetNumberOfStacks() + 1; @line < data.Length; @line++)
    {
        int move = int.Parse(data[@line].Split(" ")[1]);
        int from = int.Parse(data[@line].Split(" ")[3]);
        int to = int.Parse(data[@line].Split(" ")[5]);

        instructions.AddRange(new List<List<int>>() { new List<int>() { move, from, to } });
    }

    return instructions;
}

string PartOne()
{
    List<List<char>> stacks = ParsingDataOfStacks();
    List<List<int>> rearrangement = ParsingRearrangementInput();

    foreach (List<int> instructions in rearrangement)
    {
        int move = instructions[0];
        int from = instructions[1] - 1;
        int to = instructions[2] - 1;

        foreach (int step in Enumerable.Range(0, move))
        {
            char temp = stacks[from][^1];
            stacks[from].RemoveAt(stacks[from].Count - 1);
            stacks[to].Add(temp);
        }
    }

    StringBuilder result = new StringBuilder();

    foreach (List<char> stack in stacks)
    {
        result.Append(stack[^1]);
    }

    return result.ToString();
}

string PartTwo()
{
    List<List<char>> stacks = ParsingDataOfStacks();
    List<List<int>> rearrangement = ParsingRearrangementInput();

    foreach (List<int> instructions in rearrangement)
    {
        int move = instructions[0];
        int from = instructions[1] - 1;
        int to = instructions[2] - 1;

        for (int step = move; step > 0; step--)
        {
            char temp = stacks[from][^step];
            stacks[from].RemoveAt(stacks[from].Count - step);
            stacks[to].Add(temp);
        }
    }

    StringBuilder result = new StringBuilder();

    foreach (List<char> stack in stacks)
    {
        result.Append(stack[^1]);
    }

    return result.ToString();
}

Console.WriteLine($"Crates on top of each stack after the rearrangement procedure: {PartOne()}");
Console.WriteLine($"Crates on top of each stack after the rearrangement procedure, with the CrateMover 9001: {PartTwo()}");