namespace Day7;

class Program
{
    public static void Main()
    {
        string input = "input.txt";

        Program Day7 = new Program();
        Directory root = Day7.CreateFileSystem(input);

        int partOne = Day7.PartOne(root);
        int partTwo = Day7.PartTwo(root);

        Console.WriteLine($"Sum of the size of directories with a total size of at most 100000 byte: {partOne}");
        Console.WriteLine($"Size of the smallest directory that, if deleted, would free up enough space: {partTwo}");
    }

    public Directory CreateFileSystem(string input)
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
                    Directory mainDirectory = root.ReturnDirectoryByPath(actualPath.Substring(0, actualPath.Length - 1), root)!;
                    mainDirectory.Directories.Add(subDirectory);
                }
            }

            int fileSize;

            if (int.TryParse(commands[0], out fileSize))
            {
                string fileName = commands[1];
                Document newDocument = new Document(fileName, fileSize);
                Directory mainDirectory = root.ReturnDirectoryByPath(actualPath.Substring(0, actualPath.Length - 1), root)!;
                mainDirectory.Documents.Add(newDocument);
            }
        }

        return root;
    }

    public int PartOne(Directory root)
    {
        root.SubDirectoriesBySize = new();
        root.CountSizeOfDirectory(root, 100000, true);
        int result = root.SubDirectoriesBySize.Sum();
        return result;
    }

    public int PartTwo(Directory root)
    {
        root.SubDirectoriesBySize = new();
        int availableSpace = 70000000;
        int needSpace = 30000000;
        int usedSpace = root.CountSizeOfDirectory(root, 0, false);
        int unusedSpace = availableSpace - usedSpace;
        int needToRemove = needSpace - unusedSpace;
        
        root.CountSizeOfDirectory(root, needToRemove, false);

        int minimumToRemove = root.SubDirectoriesBySize.Min();

        return minimumToRemove;
    }
}