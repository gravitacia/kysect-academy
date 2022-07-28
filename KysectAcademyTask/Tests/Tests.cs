using KysectAcademyTask.Config;
using NUnit.Framework;

namespace KysectAcademyTask.Tests;

public class Tests
{
    private IAlgorithmLogic _algorithm;
    private Configuration _configuration;
    
    [SetUp]
    public void Setup()
    {
        _algorithm = new ComparisonLogic();
        _configuration = new Configuration();
    }

    [Test]
    public void BaseAlgoScript_CompareResult()
    {
        List<List<double>> compareResult = new Comparator().CompareAlgorithm(_configuration.RootPath[0]);
        var comparisonResult = new ComparisonResult(_configuration.RootPath[0], compareResult);

        new Output.Output().OutputResults(_configuration.ResultFilter.FileType, 
            _configuration.ResultFilter.PathForResults, comparisonResult);
    }
    
}