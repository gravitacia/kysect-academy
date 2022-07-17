var dir =  new DirectoryInfo(@"C:\Users\Alef Computers\Desktop\RootDirectory\M3234\Emily Larson\6. Знакомство с паттернами\20191230002428");
IEnumerable<FileInfo> list1 = dir.GetFiles("*.*", SearchOption.AllDirectories);

foreach (FileInfo cur in list1)
{
    Console.WriteLine(cur.Directory);
}