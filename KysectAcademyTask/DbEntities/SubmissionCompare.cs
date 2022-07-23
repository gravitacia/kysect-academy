namespace KysectAcademyTask.DbEntities;

public class SubmissionCompare
{
    public int MixedId { get; set; }
    public string FirstSubmission { get; set; }
    public string SecondSubmission { get; set; }
    public double Result { get; set; }
}