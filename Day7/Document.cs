namespace Day7;

class Document
{
    public string Name { get; set; }
    public int Size { get; set; }

    public Document(string _name, int _size)
    {
        Name = _name;
        Size = _size;
    }
}