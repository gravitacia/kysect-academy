namespace KysectAcademyTask;

public class Output
{
    public void OutputResult(string firstPath, string secondPath)
    {
        double compareResult = new Comparator().CompareAlgorithm(firstPath, secondPath);
        
        Console.WriteLine($"First file: {firstPath}, Second file: {secondPath}, Percent: {compareResult} ");
    }
}