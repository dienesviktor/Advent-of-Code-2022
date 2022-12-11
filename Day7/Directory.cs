namespace Day7;

class Directory
{
    private string path;
    public List<Directory> Directories { get; set; }
    public List<Document> Documents { get; set; }
    public List<int> SubDirectoriesBySize { get; set; }

    public Directory(string _path)
    {
        path = _path;
        Directories = new();
        Documents = new();
        SubDirectoriesBySize = new();
    }

    public Directory? ReturnDirByPath(string path, Directory mainDirectory)
    {
        Directory directory = null;

        foreach (Directory subDirectory in mainDirectory.Directories)
        {
            if (subDirectory.path == path)
            {
                return subDirectory;
            }
            else
            {
                directory = ReturnDirByPath(path, subDirectory)!;
                if (directory != null) return directory;
            }
        }

        return directory;
    }

    public int CountSizeOfDirectory(Directory directory, int maxSize)
    {
        int total = 0;

        foreach (Document document in directory.Documents)
        {
            total += document.Size;
        }

        foreach (Directory subDirectory in directory.Directories)
        {
            int directorySize = CountSizeOfDirectory(subDirectory, maxSize);
            if (directorySize <= maxSize)
            {
                SubDirectoriesBySize.Add(directorySize);
            }
            total += directorySize;
        }

        return total;
    }


}