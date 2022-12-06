using System.Text;

string input = "input.txt";

char[] data = File.ReadAllLines(input)[0].ToCharArray();

bool IsUniqueCharacters(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (str[i] == str[j]) return false;
        }
    }

    return true;
}

int PartOne()
{
    for (int i = 0; i < data.Length; i++)
    {
        StringBuilder temp = new StringBuilder();

        if (i > 3)
        {
            for (int j = i - 4; j < i; j++)
            {
                temp.Append(data[j]);
            }

            if (IsUniqueCharacters(temp.ToString()))
            {
                return i;
            }
        }
    }

    return -1;
}

int PartTwo()
{
    for (int i = 0; i < data.Length; i++)
    {
        StringBuilder temp = new StringBuilder();

        if (i > 13)
        {
            for (int j = i - 14; j < i; j++)
            {
                temp.Append(data[j]);
            }

            if (IsUniqueCharacters(temp.ToString()))
            {
                return i;
            }
        }
    }

    return -1;
}

Console.WriteLine($"Number of characters needs to be processed before the first start-of-packet marker is detected: {PartOne()}");
Console.WriteLine($"Number of characters needs to be processed before the first start-of-packet marker is detected - 14 distinct character: {PartTwo()}");