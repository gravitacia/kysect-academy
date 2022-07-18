using System.Text.Json;
using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Output
{
    private Configuration _configuration = new Configuration();

    public void OutputResult()
    {
        if (_configuration.ResultFilter?.PathForResults?.Length != 0)
        {
            if (_configuration.ResultFilter?.FileType!.ToUpper() == "JSON")
            {
                using var fs = new FileStream(_configuration.ResultFilter?.PathForResults!, FileMode.OpenOrCreate);
                double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath?[0]!, _configuration.RootPath?[1]!);
                var result = new ComparisonResult(_configuration.RootPath?[0]!, _configuration.RootPath?[1]!, compareResult);
                JsonSerializer.SerializeAsync<ComparisonResult>(fs, result);
            }
            else if (_configuration.ResultFilter?.FileType!.ToUpper() == "TXT")
            {
                try
                {
                    double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath?[0]!, _configuration.RootPath?[1]!);
                    var sw = new StreamWriter(_configuration.ResultFilter?.PathForResults!);
                    sw.WriteLine(_configuration.RootPath?[0]! + _configuration.RootPath?[1]! + compareResult);
                    sw.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            else if (_configuration.ResultFilter?.FileType!.ToUpper() == "CONSOLE")
            {
                double compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath?[0]!, _configuration.RootPath?[1]!);
                Console.WriteLine($"First path: {_configuration.RootPath?[0]!}, Second path: {_configuration.RootPath?[1]!}, Percent: {compareResult} ");
            }
            
        }
    }
}