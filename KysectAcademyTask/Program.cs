using KysectAcademyTask;

var content = Deserializer.GetContent();
var comparator = new Comparator();


if (content != null) new ComparisonLogic().GetResults(content.RootPath, content.PathForResults, comparator);
