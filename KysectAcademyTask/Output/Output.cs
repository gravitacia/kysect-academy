using KysectAcademyTask.Config;

namespace KysectAcademyTask.Output;

public class Output : IOutput
{
   public void OutputResults(Configuration configuration)
   {
      switch (configuration.ResultFilter.FileType.ToUpper())
      {
         case "CONSOLE":
            new OutputInConsole().OutputResults(configuration);
            break;
         case "JSON":
            new OutputInJson().OutputResults(configuration);
            break;
         case "TXT":
            new OutputInTxt().OutputResults(configuration);
            break;
      }
   }
}
