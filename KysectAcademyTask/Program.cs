using KysectAcademyTask;
using KysectAcademyTask.Config;

//string? rootPath = Deserializer.GetRootPath();
//string? pathToSerialize = Deserializer.GetResultsPath();

//new ComparisonLogic().GetResults(rootPath, pathToSerialize);

ResultFilter? res = new Deserializer().GetResultFilter();

Console.WriteLine(res.PathForResults, res.FileType);
