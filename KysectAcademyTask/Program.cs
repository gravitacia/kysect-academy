using KysectAcademyTask;
using KysectAcademyTask.Config;
using KysectAcademyTask.Output;


var configuration = new Configuration();
double compareResult = new Comparator().CompareAlgorithm(configuration.RootPath[0], configuration.RootPath[1]);

new Output().OutputResults(configuration, compareResult);