namespace KysectAcademyTask.Config;

public class ConfigFilter
{
    public bool IsFileAllowed(Configuration configuration, FileInfo firstFile, FileInfo secondFile)
    {
        return Convert.ToString(configuration.FileFilter?.ExtensionsWhiteList) ==
               firstFile.Extension
               && Convert.ToString(configuration.FileFilter?.ExtensionsWhiteList) ==
               secondFile.Extension;
    }

    public bool IsFileBanned(Configuration configuration, FileInfo firstFile, FileInfo secondFile)
    {
        return Convert.ToString(configuration.FileFilter?.ExtensionsBlackList) ==
               firstFile.Extension
               || Convert.ToString(configuration.FileFilter?.ExtensionsBlackList) ==
               secondFile.Extension;
    }

    public bool IsDirectoryCorrect(Configuration configuration, DirectoryInfo? firstDir, DirectoryInfo? secondDir)
    {
        return secondDir != null && firstDir != null && (firstDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.FileFilter
                                                                 ?.DirectoriesBlackList))
                                                         || !secondDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.FileFilter
                                                                 ?.DirectoriesBlackList)));
    }

    public bool IsAuthorAllowed(Configuration configuration, DirectoryInfo? firstDir, DirectoryInfo? secondDir)
    {
        return firstDir != null && secondDir != null && (secondDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.AuthorFilter
                                                                 ?.AuthorsWhiteList))
                                                         && firstDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.AuthorFilter
                                                                 ?.AuthorsWhiteList)));
    }

    public bool IsAuthorBanned(Configuration configuration, DirectoryInfo? firstDir, DirectoryInfo? secondDir)
    {
        return firstDir != null && secondDir != null && (secondDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.AuthorFilter
                                                                 ?.AuthorsBlackList))
                                                         || firstDir.GetDirectories()
                                                             .Contains<>(Convert.ToString(configuration.AuthorFilter
                                                                 ?.AuthorsBlackList)));
    }
}