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

        IEnumerable<FileInfo> firstList = firstDir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = secondDir.GetFiles("*.*", SearchOption.AllDirectories);
        double result = 0.0;

        result = new ComparisonLogic().CompareFolders(firstList, secondList);


        IEnumerable<FileInfo> finalFirstList = firstList.Where(f =>
                (bool)_configuration.FileFilter?.ExtensionsWhiteList!
                    .Any(x => f.Name.EndsWith(x)))
            .Except(firstList.Where(dir => dir.DirectoryName != null &&
                                         (bool)_configuration.FileFilter?.ExtensionsBlackList!
                                             .Any(x => dir.DirectoryName.Contains(x))))
            .Intersect(firstList.Where(author => author.DirectoryName != null 
                                                 && (bool)_configuration.AuthorFilter?.AuthorsWhiteList!
                                                     .Any(x => author.DirectoryName.Contains(x))))
            .Except(firstList.Where(author => author.DirectoryName != null 
                                              && (bool)_configuration.AuthorFilter?.AuthorsBlackList!
                                                  .Any(x => author.DirectoryName.Contains(x))));
        
        IEnumerable<FileInfo> finalSecondList = secondList.Where(f =>
                (bool)_configuration.FileFilter?.ExtensionsWhiteList!
                    .Any(x => f.Name.EndsWith(x)))
            .Except(secondList.Where(dir => dir.DirectoryName != null &&
                                           (bool)_configuration.FileFilter?.ExtensionsBlackList!
                                               .Any(x => dir.DirectoryName.Contains(x))))
            .Intersect(secondList.Where(author => author.DirectoryName != null 
                                                  && (bool)_configuration.AuthorFilter?.AuthorsWhiteList!
                                                      .Any(x => author.DirectoryName.Contains(x))))
            .Except(secondList.Where(author => author.DirectoryName != null 
                                               && (bool)_configuration.AuthorFilter?.AuthorsBlackList!
                                                   .Any(x => author.DirectoryName.Contains(x))));

        return result;
    }
}