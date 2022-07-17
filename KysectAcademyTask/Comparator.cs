using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Comparator
{
    private Configuration _configuration = new Configuration();
    private ConfigFilter _filter = new ConfigFilter();

    public double CompareAlgorithm(string firstPath, string secondPath)
    {
        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");

        var firstDir = new DirectoryInfo(secondPath);
        var secondDir = new DirectoryInfo(firstPath);

        IEnumerable<FileInfo> firstList = secondDir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = firstDir.GetFiles("*.*", SearchOption.AllDirectories);
        double result = 0.0;






        foreach (FileInfo curFirstFile in firstList)
        {
            foreach (FileInfo curSecondFile in secondList)
            {
                if (_configuration.AuthorFilter?.AuthorsWhiteList?.Count != 0)
                {
                    if (_filter.IsAuthorAllowed(_configuration, firstDir, secondDir))
                    {
                        if (_configuration.FileFilter?.DirectoriesBlackList?.Count != 0)
                        {
                            if (_filter.IsDirectoryCorrect(_configuration, secondDir, firstDir))
                            {
                                if (_configuration.FileFilter?.ExtensionsWhiteList?.Count != 0)
                                {
                                    if (_filter.IsFileAllowed(_configuration, curFirstFile, curSecondFile))
                                    {
                                        result = new ComparisonLogic().CompareFolders(firstList, secondList);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return result;
    }
}