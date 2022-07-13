namespace KysectAcademyTask;

public class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
{
    public FileCompare() { }

    public bool Equals(FileInfo? x, FileInfo? y)
    {
        return (x?.Name == y?.Name &&
                x?.Length == y?.Length);
    }

    // Return a hash that reflects the comparison criteria. According to the
    // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must  
    // also be equal. Because equality as defined here is a simple value equality, not  
    // reference identity, it is possible that two or more objects will produce the same  
    // hash code.  
    public int GetHashCode(System.IO.FileInfo obj)
    {
        string s = $"{obj.Name}{obj.Length}";
        return s.GetHashCode();
    }
}