using System.Text.Json;
using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Output
{

    private Configuration _configuration = new Configuration();

    public void OutputResult()
    {
        if (_configuration.ResultFilter.PathForResults.Length != 0)
        {
            switch (_configuration.ResultFilter.FileType.ToUpper())
            {
                case "JSON":
                {
                    using var fs = new FileStream(_configuration.ResultFilter.PathForResults, FileMode.OpenOrCreate);
                    double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath[0], _configuration.RootPath[1]);
                    var result = new ComparisonResult(_configuration.RootPath[0], _configuration.RootPath[1], compareResult);
                    JsonSerializer.SerializeAsync<ComparisonResult>(fs, result);
                    break;
                }
                case "TXT":
                {
                    double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath[0], _configuration.RootPath[1]);
                    var sw = new StreamWriter(_configuration.ResultFilter?.PathForResults!);
                    sw.WriteLine(_configuration.RootPath[0] + _configuration.RootPath[1] + compareResult);
                    sw.Close();
                    break;
                }
                default:
                {
                    if (_configuration.ResultFilter?.FileType!.ToUpper() == "CONSOLE")
                    {
                        double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath[0], _configuration.RootPath[1]);
                        Console.WriteLine($"First path: {_configuration.RootPath[0]}, Second path: {_configuration.RootPath[1]}, Percent: {compareResult} ");
                    }

                    break;
                }
            }
        }
    }
}
