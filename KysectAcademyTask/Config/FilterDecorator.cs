namespace KysectAcademyTask.Config;

public abstract class FilterDecorator : Configuration
{
    private Configuration configuration;

    protected FilterDecorator(Configuration configuration)
    {
        this.configuration = configuration;
    }
    
    public void GetFiltredFiles()
    {
    }
}