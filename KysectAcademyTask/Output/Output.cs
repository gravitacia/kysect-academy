using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public abstract class Output
{
    public Output(Configuration configuration)
    {
        this.configuration = configuration;
    }
    
    public Configuration configuration { get; set; }
    abstract public void OutputResults();
}
