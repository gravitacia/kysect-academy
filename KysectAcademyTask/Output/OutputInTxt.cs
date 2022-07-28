namespace KysectAcademyTask.Output;

public class OutputInTxt 
{
    public void OutputResults(ComparisonResult comparisonResult, string resultPath)
    {
        var sw = new StreamWriter(resultPath);
        sw.WriteLine(comparisonResult.Path1 + comparisonResult.Path2 + comparisonResult.Percent);
        sw.Close();
    }
}