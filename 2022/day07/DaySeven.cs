namespace DaySeven;

public class MyFile
{
    string? Name { get; set; }
    int Size { get; set; }
}

public class MyDirectory
{
    string? Name { get; set; }
    List<MyFile>? Files { get; set; }
    List<MyDirectory>? Directories { get; set; }

    public MyDirectory(
        string name
    ){
        Name = name;
    }
}
