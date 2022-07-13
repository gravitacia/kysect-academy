using KysectAcademyTask;

string? rootPath = Deserializer.GetRootPath();
string? pathToSerialize = Deserializer.GetResultsPath();

new ComparisonLogic().GetResults(rootPath, pathToSerialize);
