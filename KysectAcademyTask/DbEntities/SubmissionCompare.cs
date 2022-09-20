namespace KysectAcademyTask.DbEntities;

public class SubmissionCompare
{
    public SubmissionCompare(int mixedId, string firstPath, string secondPath, double result)
    {
    MixedId = mixedId;
        FirstSubmission = firstPath;
        SecondSubmission = secondPath;
        Result = result;
    }
    
    public int MixedId { get; set; }
    public string FirstSubmission { get; set; }
    public string SecondSubmission { get; set; }
    public double Result { get; set; }
}