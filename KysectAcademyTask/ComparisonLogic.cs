using NetDiff;

namespace KysectAcademyTask;

public class ComparisonLogic
{
    public List<ComparisonResult> CompareFiles(string? path, Comparator comparator)
    {

        var comparisonsList = new List<ComparisonResult>();
        if (path != null)
        {
            string[] allFiles = Directory.GetFiles(path);
        
            int count = 0;
        
            for (int i = 0; i < allFiles.Length - 1; i++)
            {
                for (int j = i + 1; j < allFiles.Length - 1; j++)
                {
                
                    string str1 = File.ReadAllText(allFiles[i]);
                    string str2 = File.ReadAllText(allFiles[j]);

                    IEnumerable<DiffResult<char>> results = comparator.EntitiesCompare(str1, str2);

                    count += results.Count(r => r.Status == DiffStatus.Equal);

                    double percent;
                    if (str1.Length > str2.Length)
                    {
                        percent = count / str1.Length;
                    }
                    else
                    {
                        percent = count / str2.Length;
                    }

                    var comparisonResult = new ComparisonResult(str1, str2, percent);
                    comparisonsList.Add(comparisonResult);
                }
            }
        }
        else
        {
            throw new Exception("Your path is empty!");
        }
        
        return comparisonsList;
    }
}