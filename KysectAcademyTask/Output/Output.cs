using KysectAcademyTask.Config;

namespace KysectAcademyTask.Output;

public class Output : IOutput
{
   public void OutputResults(Configuration configuration, double compareResult)
   {
      switch (configuration.ResultFilter.FileType.ToUpper())
      {
         case "CONSOLE":
            new OutputInConsole().OutputResults(configuration, compareResult);
            break;
         case "JSON":
            new OutputInJson().OutputResults(configuration, compareResult);
            break;
         case "TXT":
            new OutputInTxt().OutputResults(configuration, compareResult);
            break;
      }
   }
}
