using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInTxt : IOutput
{
    public void OutputResults(Configuration configuration, double compareResult)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        var sw = new StreamWriter(configuration.ResultFilter.PathForResults!);
        sw.WriteLine(configuration.RootPath[0] + configuration.RootPath[1] + compareResult);
        sw.Close();
    }
}