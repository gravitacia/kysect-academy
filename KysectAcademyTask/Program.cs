using KysectAcademyTask;

var content = Configuration.LoadContent();
var comparator = new Comparator();


if (content != null) new ComparisonLogic().GetResults(content.RootPath, content.PathForResults, comparator);
