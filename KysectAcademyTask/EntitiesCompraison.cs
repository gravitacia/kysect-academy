using NetDiff;

namespace KysectAcademyTask;

public class EntitiesCompare
{
    public IEnumerable<DiffResult<char>> Comparison(string firstFile, string secondFile)
    {
        return DiffUtil.Diff(firstFile, secondFile);
    }
}