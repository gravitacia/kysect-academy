namespace KysectAcademyTask;

public class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
{
    public FileCompare() { }

    public bool Equals(FileInfo? x, FileInfo? y)
    {
        return (x?.Name == y?.Name &&
                x?.Length == y?.Length);
    }
 
    public int GetHashCode(System.IO.FileInfo obj)
    {
        string s = $"{obj.Name}{obj.Length}";
        return s.GetHashCode();
    }
}