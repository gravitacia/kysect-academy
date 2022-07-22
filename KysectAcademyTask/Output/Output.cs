namespace KysectAcademyTask.Output;

public class Output
{
   public void OutputResults(string fileType, string resultPath, ComparisonResult comparisonResult)
   {
      switch (fileType.ToUpper())
      {
         case "CONSOLE":
            new OutputInConsole().OutputResults(comparisonResult);
            break;
         case "JSON":
            new OutputInJson().OutputResults(comparisonResult, resultPath);
            break;
         case "TXT":
            new OutputInTxt().OutputResults(comparisonResult, resultPath);
            break;
      }
   }
}
