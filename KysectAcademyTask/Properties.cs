namespace KysectAcademyTask;

public class Properties
{
    public Properties(string path1, string path2, double percent)
    {
        Path1 = path1;
        Path2 = path2;
        Percent = percent;
    }

    public double Percent { get; }

    public string Path2 { get; }

    public string Path1 { get; }
}