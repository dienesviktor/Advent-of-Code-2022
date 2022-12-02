string input = "input.txt";

string[] data = File.ReadAllLines(input);

List<int> all = new();

int temp = 0;

foreach (string line in data)
{
    if (line != string.Empty)
    {
        temp += Int32.Parse(line);
    }
    else
    {
        all.Add(temp);
        temp = 0;
    }
}

int mostCalories = all.Max();
int sumOfTopThree = all.OrderByDescending(x => x).Take(3).Sum();

Console.WriteLine($"Total calories carried by the best performer elf: {mostCalories}");
Console.WriteLine($"Sum of calories carried by the top three elves: {sumOfTopThree}");