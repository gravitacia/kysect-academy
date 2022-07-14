using KysectAcademyTask;

string? rootPath = Deserializer.GetRootPath();
string? pathToSerialize = Deserializer.GetResultsPath();
var comparator = new Comparator();


new ComparisonLogic().GetResults(rootPath, pathToSerialize, comparator);
