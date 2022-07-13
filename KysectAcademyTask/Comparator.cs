using NetDiff;

namespace KysectAcademyTask;

public class Comparator
{
    public IEnumerable<DiffResult<char>> EntitiesCompare(string firstFile, string secondFile)
    {
        return DiffUtil.Diff(firstFile, secondFile);
    }
}