using KysectAcademyTask;

var content = Configuration.LoadContent();
var comparator = new Comparator();


if (content != null)
    new Output().OutputResult(content.RootPath, content.PathForResults, comparator);
