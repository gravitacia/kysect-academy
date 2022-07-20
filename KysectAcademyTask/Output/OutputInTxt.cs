using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInTxt : IOutput
{
    public void OutputResults(Configuration configuration)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        double compareResult = new Comparator().CompareAlgorithm(configuration.RootPath[0], configuration.RootPath[1]);
        var sw = new StreamWriter(configuration.ResultFilter?.PathForResults!);
        sw.WriteLine(configuration.RootPath[0] + configuration.RootPath[1] + compareResult);
        sw.Close();
    }
}