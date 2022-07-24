using KysectAcademyTask.Config;
using KysectAcademyTask.DbEntities;

namespace KysectAcademyTask;

public class DbFunctions
{
    public void SaveSubmissionResult(string firstPath, string secondPath, double result)
    {
        var firstDir = new DirectoryInfo(firstPath);
        var secondDir = new DirectoryInfo(secondPath);
        
        int mixedId = Convert.ToInt32((Convert.ToInt32(firstDir.Name) + Convert.ToInt32(secondDir.Name)) / result);
        
        var submissionCompareresult = new SubmissionCompare(mixedId, firstPath, secondPath, result);

        new DbConfig().SaveSubmissionsCompare(submissionCompareresult);
    }
}