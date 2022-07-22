using KysectAcademyTask;
using KysectAcademyTask.Config;
using KysectAcademyTask.Output;


var configuration = new Configuration();
double compareResult = new Comparator().CompareAlgorithm(configuration.RootPath[0], configuration.RootPath[1]);
var comparisonResult = new ComparisonResult(configuration.RootPath[0], configuration.RootPath[1], compareResult);

new Output().OutputResults(configuration.ResultFilter.FileType, 
    configuration.ResultFilter.PathForResults, comparisonResult);