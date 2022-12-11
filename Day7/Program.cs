namespace Day7;

class Program
{
    public static void Main()
    {
        string input = "input.txt";

        Program Day7 = new Program();

        int partOne = Day7.PartOne(input);

        Console.WriteLine($"Sum of the size of directories with a total size of at most 100000 byte: {partOne}");
    }

    public int PartOne(string input)
    {
        string[] data = File.ReadAllLines(input);
        string actualPath = string.Empty;

        Directory root = new Directory("/");

        foreach (string line in data)
        {
            string[] commands = line.Split(" ");

            if (commands[1] == "cd")
            {

                if (commands[2] == "..")
                {
                    actualPath = string.Join("/", actualPath.Split('/').SkipLast(2)) + "/";
                }
                else
                {
                    if (commands[2] == "/")
                    {
                        actualPath = "/";
                    }
                    else
                    {
                        actualPath += commands[2] + "/";
                    }
                }
            }

            if (commands[0] == "dir")
            {
                Directory subDirectory = new Directory(actualPath + commands[1]);

                if (actualPath == "/")
                {
                    root.Directories.Add(subDirectory);
                }
                else
                {
                    Directory mainDirectory = root.ReturnDirByPath(actualPath.Substring(0, actualPath.Length - 1), root)!;
                    mainDirectory.Directories.Add(subDirectory);
                }
            }

            int fileSize;

            if (int.TryParse(commands[0], out fileSize))
            {
                string fileName = commands[1];
                Document newDocument = new Document(fileName, fileSize);
                Directory mainDirectory = root.ReturnDirByPath(actualPath.Substring(0, actualPath.Length - 1), root)!;
                mainDirectory.Documents.Add(newDocument);
            }
        }

        root.CountSizeOfDirectory(root, 100000);
        return root.SubDirectoriesBySize.Sum();
    }
}