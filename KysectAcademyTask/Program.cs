using KysectAcademyTask;

var content = Deserializer.GetContent();
var comparator = new Comparator();


if (content != null) new ComparisonLogic().CompareFilesInOneFolder(content.RootPath, content.ResultFilter?.PathForResults, comparator);
